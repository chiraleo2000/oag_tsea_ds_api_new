using System;
using System.IO;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;
using SaoTsea.Ds.Api.Utility;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BpmProcInstAttachmentPaymentController : BetimesControllerBase
	{
		private readonly ResourceUtility _resourceUtility;

		public BpmProcInstAttachmentPaymentController(ResourceUtility resourceUtility)
		{
			_resourceUtility = resourceUtility;
		}

		[XpoFilter]
		[HttpGet]
		public async Task<BPM_PROC_INST_ATTACHMENT_PAYMENT[]> Gets([FromQuery] BpmAttachmentFilterParam param)
		{
			string condition = "";
			if (param.BpmInstanceId.HasValue)
			{
				condition = WhereUtility.And(condition, $"INST_ID={param.BpmInstanceId}");
			}

			return await DB.GetObjectListAsync<BPM_PROC_INST_ATTACHMENT_PAYMENT>(condition);
		}


		[HttpGet("count")]
		public async Task<int> GetCount([FromQuery] BpmAttachmentFilterParam param)
		{
			int c = await DB.GetXpQuery<BPM_PROC_INST_ATTACHMENT_PAYMENT>()
			                .CountAsync(p => p.INST_ID == param.BpmInstanceId);
			return c;
		}

		[AllowAnonymous]
		[HttpPost]
		[XpoAutoUpdate]
		public async Task<StatusResult<int>> Post([FromForm] BPM_PROC_INST_ATTACHMENT_PAYMENT value)
		{
            if (value.File != null)
            {
                FileResource info = new FileResource
                {
                    FileStream = value.File.OpenReadStream(),
                    Destination = Path.Combine(
                        "attachment-payment",
                        DateTime.Now.ToString("MM-yyyy"),
                        value.INST_ID.ToString()
                    ),
                    Name = Guid.NewGuid().ToString("N"),
                    Extension = Path.GetExtension(value.File.FileName)
                };

                await _resourceUtility.SaveFile(info);
                value.INST_ATTACHMENT_PATH = info.FullPath;
                value.INST_ATTACHMENT_NAME = value.File.FileName;
                value.INST_ATTACHMENT_SIZE = Convert.ToInt32(value.File.Length);
            }

            value.INST_ATTACHMENT_DATE = DateTime.Now;
			DB.InsertObject(value);
			await DB.CommitChangesAsync();

			return StatusResult.Ok(value.INST_ATTACHMENT_PAYMENT_ID);
		}

		[AllowAnonymous]
		[HttpPost("create/batch")]
		[XpoAutoUpdate]
		public async Task<StatusResult<int>> CreateBatch([FromForm] BPM_PROC_INST_ATTACHMENT_PAYMENT[] value)
		{

			foreach (var item in value)
			{
				if (item.File != null)
				{
					FileResource info = new FileResource
					{
						FileStream = item.File.OpenReadStream(),
						Destination = Path.Combine(
							"attachment-payment",
							DateTime.Now.ToString("MM-yyyy"),
							item.INST_ID.ToString()
						),
						Name = Guid.NewGuid().ToString("N"),
						Extension = Path.GetExtension(item.File.FileName)
					};

					await _resourceUtility.SaveFile(info);
					item.INST_ATTACHMENT_PATH = info.FullPath;
					item.INST_ATTACHMENT_NAME = item.File.FileName;
					item.INST_ATTACHMENT_SIZE = Convert.ToInt32(item.File.Length);
				}
				
				item.INST_ATTACHMENT_DATE = DateTime.Now;
				DB.InsertObject(item);
			}


			await DB.CommitChangesAsync();

			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, [FromForm] BPM_PROC_INST_ATTACHMENT_PAYMENT value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[HttpDelete("{attachmentId}")]
		public async Task<StatusResult> Delete(int attachmentId)
		{
			var xpoAttachment = await DB.GetObjectByKeyAsync<BPM_PROC_INST_ATTACHMENT_PAYMENT>(attachmentId);
			if (xpoAttachment == null)
			{
				return StatusResult.Error("ไม่พบข้อมูลไฟล์แนบ");
			}

			xpoAttachment.Delete();
			await DB.CommitChangesAsync();

			string savePath = Path.Combine(_resourceUtility.ResourcePath, xpoAttachment.INST_ATTACHMENT_PATH);
			if (System.IO.File.Exists(savePath))
			{
				System.IO.File.Delete(savePath);
			}

			return StatusResult.Ok();
		}
	}
}

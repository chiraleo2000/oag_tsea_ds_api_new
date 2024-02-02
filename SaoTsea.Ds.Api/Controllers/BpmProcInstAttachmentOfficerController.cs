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
	public class BpmProcInstAttachmentOfficerController : BetimesControllerBase
	{
		private readonly ResourceUtility _resourceUtility;

		public BpmProcInstAttachmentOfficerController(ResourceUtility resourceUtility)
		{
			_resourceUtility = resourceUtility;
		}

		[XpoFilter]
		[HttpGet]
		[AllowAnonymous]
		public async Task<VIEW_PROC_INST_ATTACHMENT_OFFICER[]> Gets([FromQuery] BpmAttachmentFilterParam param)
		{
			string condition = "";
			if (param.BpmInstanceId.HasValue)
			{
				condition = WhereUtility.And(condition, $"INST_ID={param.BpmInstanceId}");
			} 
			if (!string.IsNullOrEmpty(param.PublishFlag))
			{
				condition = WhereUtility.And(condition, $"PUBLISH_FLAG='{param.PublishFlag}'");
			}
			if (param.InstAttachmentTypeId.HasValue)
			{
				condition = WhereUtility.And(condition, $"INST_ATTACHMENT_TYPE_ID={param.InstAttachmentTypeId}");
			}
			if (param.PersonalId.HasValue)
			{
				condition = WhereUtility.And(condition, $"PERSONAL_ID= '{param.PersonalId}'");
			}
			return await DB.GetObjectListAsync<VIEW_PROC_INST_ATTACHMENT_OFFICER>(condition);
		}


		[HttpGet("count")]
		public async Task<int> GetCount([FromQuery] BpmAttachmentFilterParam param)
		{
			string condition = "";
			if (param.BpmInstanceId.HasValue)
			{
				condition = WhereUtility.And(condition, $"INST_ID={param.BpmInstanceId}");
			}

			if (string.IsNullOrEmpty(param.PublishFlag))
			{
				condition = WhereUtility.And(condition, $"PUBLISH_FLAG='{param.PublishFlag}'");
			}

			int c = await DB.ConvertCriteriaToExpression<BPM_PROC_INST_ATTACHMENT_OFFICER>(condition)
			                .CountAsync(p => p.INST_ID == param.BpmInstanceId);
			return c;
		}

		[AllowAnonymous]
		[HttpPost]
		[XpoAutoUpdate]
		public async Task<StatusResult<int>> Post([FromForm] BPM_PROC_INST_ATTACHMENT_OFFICER value)
		{
			if (value.File != null)
			{
				FileResource info = new FileResource
				{
					FileStream = value.File.OpenReadStream(),
					Destination = Path.Combine(
						"attachment",
						DateTime.Now.ToString("MM-yyyy"),
						value.INST_ID.ToString()
					),
					Name = Guid.NewGuid().ToString("N"),
					Extension = Path.GetExtension(value.File.FileName)
				};

				await _resourceUtility.SaveFile(info);
				value.INST_ATTACHMENT_OFFICER_PATH = info.FullPath;
				value.INST_ATTACHMENT_OFFICER_NAME = value.File.FileName;
				value.INST_ATTACHMENT_OFFICER_SIZE = Convert.ToInt32(value.File.Length);
			}

			value.INST_ATTACHMENT_OFFICER_DATE = DateTime.Now;

			DB.InsertObject(value);

			await DB.CommitChangesAsync();

			return StatusResult.Ok(value.INST_ATTACHMENT_OFFICER_ID);
		}

		[AllowAnonymous]
		[HttpPost("create/batch")]
		[XpoAutoUpdate]
		public async Task<StatusResult<int>> CreateBatch([FromForm] BPM_PROC_INST_ATTACHMENT_OFFICER[] value)
		{

			foreach (var item in value)
			{
				if (item.File != null)
				{
					FileResource info = new FileResource
					{
						FileStream = item.File.OpenReadStream(),
						Destination = Path.Combine(
							"attachment",
							DateTime.Now.ToString("MM-yyyy"),
							item.INST_ID.ToString()
						),
						Name = Guid.NewGuid().ToString("N"),
						Extension = Path.GetExtension(item.File.FileName)
					};

					await _resourceUtility.SaveFile(info);
					item.INST_ATTACHMENT_OFFICER_PATH = info.FullPath;
					item.INST_ATTACHMENT_OFFICER_NAME = item.File.FileName;
					item.INST_ATTACHMENT_OFFICER_SIZE = Convert.ToInt32(item.File.Length);
				}
				
				item.INST_ATTACHMENT_OFFICER_DATE = DateTime.Now;
				DB.InsertObject(item);
			}


			await DB.CommitChangesAsync();

			return StatusResult.Ok();
		}

		[HttpPost("{id}/update/publish-flag")]
		[XpoAutoUpdate]
		[AllowAnonymous]
		public async Task<StatusResult> UpdatePublishFlag(int id, AttachmentOfficerParam param)
		{
			var value = await DB.GetObjectByKeyAsync<BPM_PROC_INST_ATTACHMENT_OFFICER>(id);

			if (value == null)
			{
				return StatusResult.Error("ไม่พบข้อมูลเอกสารแนบ");
			}

			value.PUBLISH_FLAG = param.PublishFlag;
			await DB.CommitChangesAsync();

			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, [FromForm] BPM_PROC_INST_ATTACHMENT_OFFICER value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[HttpDelete("{attachmentId}")]
		public async Task<StatusResult> Delete(int attachmentId)
		{
			var xpoAttachment = await DB.GetObjectByKeyAsync<BPM_PROC_INST_ATTACHMENT_OFFICER>(attachmentId);
			if (xpoAttachment == null)
			{
				return StatusResult.Error("ไม่พบข้อมูลไฟล์แนบ");
			}

			///TODO : update record for not show in ui (not real delete)
			xpoAttachment.DEL_FLAG = "Y";
			xpoAttachment.RECORD_STATUS = "I";
			xpoAttachment.UPDATE_DATE = DateTime.Now;
			xpoAttachment.UPDATE_USER_ID = UserInfo.UserId;
			DB.UpdateObject(xpoAttachment);
			await DB.CommitChangesAsync();

			//xpoAttachment.Delete();
			//await DB.CommitChangesAsync();

			//string savePath = Path.Combine(_resourceUtility.ResourcePath, xpoAttachment.INST_ATTACHMENT_OFFICER_PATH);
			//if (System.IO.File.Exists(savePath))
			//{
			//	System.IO.File.Delete(savePath);
			//}

			return StatusResult.Ok();
		}

        [HttpPut("{id}/update/document/ca")]
        [XpoAutoUpdate]
        [AllowAnonymous]
        public async Task<StatusResult> updateDocumentCa(int id, AttachFileOfficerForCA param)
        {
            var value = await DB.GetObjectByKeyAsync<BPM_PROC_INST_ATTACHMENT_OFFICER>(id);
            if (value == null)
            {
                return StatusResult.Error("ไม่พบข้อมูลเอกสารแนบ");
            }
			value.INST_ATTACHMENT_OFFICER_PATH = param.INST_ATTACHMENT_OFFICER_PATH;
			value.UPDATE_DATE = DateTime.Now;
			value.UPDATE_USER_ID = -55;
            await DB.CommitChangesAsync();

            return StatusResult.Ok();
        }
    }
}

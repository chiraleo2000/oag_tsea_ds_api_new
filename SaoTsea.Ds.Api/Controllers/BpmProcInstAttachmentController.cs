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
	public class BpmProcInstAttachmentController: BetimesControllerBase
	{
		private readonly ResourceUtility _resourceUtility;

		public BpmProcInstAttachmentController(ResourceUtility resourceUtility)
		{
			_resourceUtility = resourceUtility;
		}

		[XpoFilter]
		[HttpGet]
		public async Task<VIEW_PROC_INST_ATTACHMENT[]> Gets([FromQuery] BpmAttachmentFilterParam param)
		{
			string condition = "";
			if (param.BpmInstanceId.HasValue)
			{
				condition = WhereUtility.And(condition, $"INST_ID={param.BpmInstanceId}");
			}

			return await DB.GetObjectListAsync<VIEW_PROC_INST_ATTACHMENT>(condition);
		}


		[HttpGet("count")]
		public async Task<int> GetCount([FromQuery] BpmAttachmentFilterParam param)
		{
			int c = await DB.GetXpQuery<BPM_PROC_INST_ATTACHMENT>()
			                .CountAsync(p => p.INST_ID == param.BpmInstanceId);
			return c;
		}

		[AllowAnonymous]
		[HttpPost]
		[XpoAutoUpdate]
		public async Task<StatusResult<int>> Post([FromForm] BPM_PROC_INST_ATTACHMENT value)
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
				value.INST_ATTACHMENT_PATH = info.FullPath;
				value.INST_ATTACHMENT_NAME = value.File.FileName;
				value.INST_ATTACHMENT_SIZE = Convert.ToInt32(value.File.Length);
			}

			value.INST_ATTACHMENT_DATE = DateTime.Now;
			DB.InsertObject(value);
			await DB.CommitChangesAsync();

			return StatusResult.Ok(value.INST_ATTACHMENT_ID);
		}

		[AllowAnonymous]
		[HttpPost("create/batch")]
		[XpoAutoUpdate]
		public async Task<StatusResult<int>> CreateBatch([FromForm] BPM_PROC_INST_ATTACHMENT[] value)
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
		public async Task<StatusResult> Put(int id, [FromForm] BPM_PROC_INST_ATTACHMENT value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		
		[HttpDelete("{attachmentId}")]
		public async Task<StatusResult> Delete(int attachmentId)
		{
			var xpoAttachment = await DB.GetObjectByKeyAsync<BPM_PROC_INST_ATTACHMENT>(attachmentId);
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

		//[AllowAnonymous]
		//[HttpDelete("{InstId}/InstId")]
		//public async Task<StatusResult> DeleteByInstId(int InstId)
		//{
		//	var xpoAttachment = await DB.GetObjectListAsync<BPM_PROC_INST_ATTACHMENT>($"INST_ID={InstId} AND INST_ATTACHMENT_ACTION_FLAG='V'");
		//	if (xpoAttachment != null)
		//	{
		//		await DB.Session.ExecuteNonQueryAsync($"DELETE FROM BPM_PROC_INST_ATTACHMENT WHERE INST_ID={InstId} AND INST_ATTACHMENT_ACTION_FLAG='V'");
		//		await DB.CommitChangesAsync();
		//		foreach (var item in xpoAttachment)
		//		{
		//			string savePath = Path.Combine(_resourceUtility.ResourcePath, item.INST_ATTACHMENT_PATH);
		//			if (System.IO.File.Exists(savePath))
		//			{
		//				System.IO.File.Delete(savePath);
		//			}
		//		}
		//	}
			
		//	return StatusResult.Ok();
		//}

		[XpoFilter]
		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<BPM_PROC_INST_ATTACHMENT[]> GetById(string id)
		{
			//return await DB.GetObjectListAsync<BPM_PROC_INST_ATTACHMENT>($"INST_ATTACHMENT_TYPE_ID='{id}'");
			return await DB.GetObjectListAsync<BPM_PROC_INST_ATTACHMENT>($"INST_ATTACHMENT_TYPE_ID='{id}'");
		}
	}
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

// เพิ่มเพื่อตรวจสอบนามสกุลไฟล์

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EdocAssignController : BetimesControllerBase
	{
		private readonly ResourceUtility _resourceUtility;
		public EdocAssignController(ResourceUtility resourceUtility)
		{
			_resourceUtility = resourceUtility;
		}

		// new
		[XpoFilter]
		[HttpGet("getByAssigner/{id}")] // เรียกดูว่าเรามอบหมายใคร
		[AllowAnonymous]
		public async Task<VIEW_EDOC_ASSIGN[]> GetByAssigner(string id)
		{
			return await DB.GetObjectListAsync<VIEW_EDOC_ASSIGN>($"ASSIGNER_PERSONAL_ID='{id}'");
		}

		[XpoFilter]
		[HttpGet("getByAssignee/{id}")] // เรียกดูว่าใครมอบหมายเรา
		[AllowAnonymous]
		public async Task<VIEW_EDOC_ASSIGN[]> GetByAssignee(string id)
		{
			return await DB.GetObjectListAsync<VIEW_EDOC_ASSIGN>($"ASSIGNEE_PERSONAL_ID='{id}'");
		}

		[XpoFilter]
		[HttpGet("getByOrganizeId/{id}")] // เรียกดูว่าผู้รับมอบหมายเขตเรา
		//[AllowAnonymous]
		public async Task<VIEW_PERSONAL[]> GetByDistick(string id)
		{
			return await DB.GetObjectListAsync<VIEW_PERSONAL>($"ORG_ID='{id}' AND ORGANIZE_LEVEL >= '{UserInfo.OrganizeLevel}' AND USER_TYPE=2");
		}
		// end new

		[XpoFilter]
		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<VIEW_EDOC_ASSIGN[]> GetById(string id)
		{
			return await DB.GetObjectListAsync<VIEW_EDOC_ASSIGN>($"ASSIGNER_DISTICT_ID='{id}'");
		}

		[XpoFilter]
		[HttpGet("getPersonal")]
		[AllowAnonymous]
		public async Task<VIEW_PERSONAL[]> GetPersonal()
		{
			var districtId = UserInfo.DistrictId;
			return await DB.GetObjectListAsync<VIEW_PERSONAL>($"DISTICT_ID='{districtId}'");
		}

		// รอแก้ พาร์ทสลับ \ เป็น /
		[XpoAutoUpdate]
		[HttpPost("{id}")]
		[RequestSizeLimit(2500000)]
		public async Task<StatusResult> Post([FromForm] EDOC_TXN_ASSIGN value, string id)
		{

			if (value.ATTACHMENT_FILE != null)
			{
				ImageResource info = new ImageResource // กำหนดชื่อไฟล์ เพื่อบันทึกพาร์ทไฟล์
				{
					File = value.ATTACHMENT_FILE,
					Destination = Path.Combine(
						"attachment", 
						"root_"+id, 
						"edoc_assign", 
						DateTime.Now.ToString("yyyy-MM")),
					// Type = MagickFormat.Png,
					// Extension = Path.GetExtension(value.ATTACHMENT_FILE.FileName),
					Name = Guid.NewGuid().ToString("N")
				};

				await _resourceUtility.SaveImageToResource(info); // ใช้ method กลางเพื่ออัพโหลดไฟล์
				value.ATTACHMENT_PATH = info.FullPath; // นำพาร์ทที่ได้มาใส่ใน DB
			}

			// DB.UpdateObject(value);
			await DB.CommitChangesAsync();
			DB.InsertObject(value);
			return StatusResult.Ok();
		}

		//[XpoAutoUpdate]
		//[HttpPut("{id}")]
		//[RequestSizeLimit(2500000)]
		//public async Task<StatusResult> Put(int id, [FromForm] EDOC_TXN_ASSIGN value)
		//{
		//	EDOC_TXN_ASSIGN data = await DB.GetObjectByKeyAsync<EDOC_TXN_ASSIGN>(id);

		//	if (data == null)
		//	{
		//		return StatusResult.Error("ไม่พบข้อมูลที่ส่งมา");
		//	}

		//	if (value.ATTACHMENT_PATH != null)
		//	{
		//		ImageResource info = new ImageResource // กำหนดชื่อไฟล์ เพื่อบันทึกพาร์ทไฟล์
		//		{
		//			File = value.ATTACHMENT_PATH,
		//			Destination = Path.Combine(
		//				"attachment",
		//				"root_" + id,
		//				"edoc_assign",
		//				DateTime.Now.ToString("yyyy-MM")),
		//			// Type = MagickFormat.Png,
		//			// Extension = Path.GetExtension(value.ATTACHMENT_FILE.FileName),
		//			Name = Guid.NewGuid().ToString("N"),
		//		};

		//		await _resourceUtility.SaveImageToResource(info); // ใช้ method กลางเพื่ออัพโหลดไฟล์
		//		value.ATTACHMENT_PATH = info.FullPath; // นำพาร์ทที่ได้มาใส่ใน DB
		//	}
		//	// DB.UpdateObject(value);
		//	await DB.CommitChangesAsync();
		//	return StatusResult.Ok();
		//}

		[HttpDelete("{id}/attachment")]
		public async Task<StatusResult> DeleteAttachment(int id)
		{
			var assignData = await DB.GetObjectByKeyAsync<EDOC_TXN_ASSIGN>(id);
			if (assignData == null)
			{
				return StatusResult.Error("ไม่พบข้อมูล");
			}

			if (string.IsNullOrEmpty(assignData.ATTACHMENT_PATH))
			{
				return StatusResult.Error("ไม่พบข้อมูลไฟล์แนบ");
			}
			else
			{
				// await _resourceUtility.DeleteFile(assignData.ATTACHMENT_PATH);
			}

			assignData.ATTACHMENT_PATH = null;
			assignData.ATTACHMENT_HASH = null;

			DB.UpdateObject(assignData);

			await DB.CommitChangesAsync();

			return StatusResult.Ok();
		}

		[XpoFilter]
		[HttpGet("nee/{id}")]
		[AllowAnonymous]
		public async Task<VIEW_EDOC_ASSIGN[]> GetNee(string id)
		{
			return await DB.GetObjectListAsync<VIEW_EDOC_ASSIGN>($"ASSIGNEE_PERSONAL_ID='{id}'");
        }


		[HttpPost("cancel")]
		public async Task<StatusResult> cancel(EDOC_TXN_ASSIGN param)
		{
			EDOC_TXN_ASSIGN info = await DB.GetObjectByKeyAsync<EDOC_TXN_ASSIGN>(param.EDOC_ASSIGN_ID);
            if (info == null)
            {
				return StatusResult.Error("ไม่พบข้อมูลรักษาการแทน");
			}

			info.DESCRIPTION_CANCEL = param.DESCRIPTION_CANCEL;
			info.CANCEL_FLAG = "Y";
			DB.UpdateObject(info);
			await DB.CommitChangesAsync();

			return StatusResult.Ok();
		}


		[XpoFilter]
		[HttpGet("getByAssigner")] // ชื่อผุ้มอบหมายงาน
		public async Task<VIEW_PERSONAL> getByPersonal()
		{
			string personalId = UserInfo.PersonalId.ToString();
			return await DB.GetObjectAsync<VIEW_PERSONAL>($"PERSONAL_ID='{personalId}'");
		}

	}
}

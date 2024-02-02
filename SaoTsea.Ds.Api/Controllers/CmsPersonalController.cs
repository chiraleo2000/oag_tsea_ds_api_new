using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using ImageMagick;
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
	public class CmsPersonalController : BetimesControllerBase
	{
		private readonly AppSetting _setting;

		public CmsPersonalController(AppSetting setting)
		{
			_setting = setting;
		}

		[LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<StatusResult<VIEW_PERSONAL[]>> Gets([FromQuery] FilterParam filter)
		{
			string condition = "";

            VIEW_PERSONAL[] personalInfo = await DB.GetObjectListAsync<VIEW_PERSONAL>(condition);
			return StatusResult.Ok(personalInfo);
		}

        [LoadRole]
		[HttpGet("{personalId}")]
		public async Task<VIEW_PERSONAL> GetByPersonalId(int personalId)
		{
			return await DB.GetObjectByKeyAsync<VIEW_PERSONAL>(personalId);
		}
		
		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post([FromForm] CMS_PERSONAL param,
			[FromServices] ResourceUtility _resourceUtility)
		{
			if (string.IsNullOrEmpty(param.NEW_PASSWORD))
			{
				return StatusResult.Error("ไม่พบรหัสผ่าน");
			}

			if (string.IsNullOrEmpty(param.USER_NAME))
			{
				return StatusResult.Error("ไม่พบชื่อผู้ใช้งาน");
			}

			//if (!string.IsNullOrEmpty(param.PERSONAL_CITIZEN_NUMBER))
			//{
			//	param.PERSONAL_CITIZEN_NUMBER = CryptoHelper
			//		.EncryptString(param.PERSONAL_CITIZEN_NUMBER,
			//			_setting.Keys.EncryptKey);
			//}

			if (param.UPLOAD_SIGNATURE_PICTURE != null)
			{
				ImageResource info = new ImageResource
				{
					File = param.UPLOAD_SIGNATURE_PICTURE,
					Destination = Path.Combine("img", "user", "root_" + param.ORG_ID,
						param.PERSONAL_ID.ToString()),
					Type = MagickFormat.Jpg,
					Name = "signature"
				};

				await _resourceUtility.SaveImageToResource(info);
				param.PERSONAL_SIGNATURE_PICTURE = info.FullPath;
			}

			await DB.CommitChangesAsync();

			ADM_USER user = new ADM_USER(DB.Session)
			{
				PERSONAL_ID = param.PERSONAL_ID,
				USER_NAME = param.USER_NAME,
				USER_APPROVE_FLAG = "A"
			};

			if (param.PERSONAL_TYPE_ID == 7)
				user.USER_TYPE = 1;
			else
				user.USER_TYPE = 2;

			if (param.UPLOAD_PICTURE != null)
			{
				ImageResource info = new ImageResource
				{
					ImageStream = param.UPLOAD_PICTURE.OpenReadStream(),
					Destination = Path.Combine("img", "user", "root_" + param.ORG_ID,
						param.PERSONAL_ID.ToString()),
					Type = MagickFormat.Jpg,
					Name = "profile"
				};

				await _resourceUtility.SaveImageToResource(info);
				user.USER_PICTURE = info.FullPath;
			}

			user.USER_PASSWORD = CryptoHelper.CreateSha256(param.NEW_PASSWORD);
			DB.InsertObject(user);

			await DB.CommitChangesAsync();

			if (param.SYNC_USER_CAMUNDA)
			{
				//var userInfo = new UserProfileInfo()
				//{
				//	Id = user.USER_NAME,
				//	FirstName = param.PERSONAL_FNAME_THA,
				//	LastName = param.PERSONAL_LNAME_THA,
				//	Email = param.PERSONAL_EMAIL
				//};
				//string pass = CryptoHelper.CreateSha256(user.USER_PASSWORD);

				//await camunda.CreateUserAsync(userInfo, pass);

			}

			return StatusResult.Ok();
		}

		[LoadRole]
		[XpoFilter]
		[HttpPost("search")]
		public async Task<PagingResult<SearchPersonalResult>> Search(SearchParam param)
		{
			DB.ConditionContext.MapFieldName(_ => _.SelfRootId, "ORGANIZE_ROOT_ID");
			DB.ConditionContext.DeleteFlag = false;
			return await DB.StoredProcedure.SearchPersonal(
				DB.ConditionContext.ToSql(param.Condition),
                param.Offset ?? 0,
				param.Length ?? 100);
		}
		
        [LoadRole]
		[XpoFilter]
		[HttpPost("organize/role")]
		public async Task<IEnumerable<OrganizeProvinceUser>> GetPersonalByRole(OrganizeRoleUserParam param)
		{
			// Old Code
			//var op = await DB.GetObjectListAsync<CMS_ORGANIZE>(
			//	$"ORGANIZE_CODE_LEV1_OLD = '{ param.MainCode }' AND " +
			//	$"ORGANIZE_CODE_LEV2_OLD = '{ param.DepartmetCode }' AND " +
			//	$"ORGANIZE_CODE_LEV3_OLD = '{ param.DivisionCode }' AND " +
			//	$"ORGANIZE_CODE_LEV4_OLD = '{ param.SectionCode }' AND " +
			//	$"ORGANIZE_CODE_LEV5_OLD = '{ param.JobCode }' ");
			//if (op == null)
			//{
			//	return null;
			//}

			//string organizeComma = op.Select(p => p.ORGANIZE_ID.ToString())
			//						 .Aggregate((_old, _new) => $"{_new},{_old}");

			//var personal = await DB.GetObjectListAsync<VIEW_USER_ROLE>(
			//	$"ORGANIZE_ID IN ({organizeComma}) AND ROLE_CODE = '{ param.RoleCode }'");


			//return personal?.Select(p => new OrganizeProvinceUser()
			//{
			//	PersonalId = p.PERSONAL_ID,
			//	Username = p.USER_NAME
			//});
			ADM_ROLE_INFO role = await DB.GetObjectAsync<ADM_ROLE_INFO>($"ROLE_CODE = '{param.RoleCode}'");
			int levRole = role.ORG_LV;

			var op = await DB.GetObjectListAsync<CMS_ORGANIZE>(
				$"ORGANIZE_CODE_LEV1_OLD = '{ param.MainCode }' AND " +
				$"ORGANIZE_CODE_LEV2_OLD = '{(levRole >= 2 ? param.DepartmetCode : "00")}' AND " +
				$"ORGANIZE_CODE_LEV3_OLD = '{(levRole >= 3 ? param.DivisionCode : "00")}' AND " +
				$"ORGANIZE_CODE_LEV4_OLD = '{(levRole >= 4 ? param.SectionCode : "00")}' AND " +
				$"ORGANIZE_CODE_LEV5_OLD = '{(levRole >= 4 ? param.JobCode : "00")}' ");
			if (op == null)
			{
				return null;
			}

			string organizeComma = op.Select(p => p.ORGANIZE_ID.ToString())
								 .Aggregate((_old, _new) => $"{_new},{_old}");

			var personal = await DB.GetObjectListAsync<VIEW_USER_ROLE>(
				$"ORGANIZE_ID IN ({organizeComma}) AND ROLE_CODE = '{ param.RoleCode }'");

			return personal?.Select(p => new OrganizeProvinceUser()
			{
				PersonalId = p.PERSONAL_ID,
				Username = p.USER_NAME
			});
		}

        [LoadRole]
		[XpoFilter]
		[HttpPost("role")]
		public async Task<IEnumerable<OrganizeProvinceUser>> GetPersonalRole(OrganizeRoleUserParam param)
		{
			var personal = await DB.GetObjectListAsync<VIEW_USER_ROLE>(
				$"ROLE_CODE = '{ param.RoleCode }'");


			return personal?.Select(p => new OrganizeProvinceUser()
			{
				PersonalId = p.PERSONAL_ID,
				Username = p.USER_NAME
			});
		}
		
        [LoadRole]
		[XpoFilter]
		[HttpPost("organize/district")]
		public async Task<string> GetPersonalByDistrict(OrganizeRoleUserParam param)
		{
			var op = await DB.GetObjectListAsync<CMS_ORGANIZE>(
				$"organize_code_lev1_old = '{ param.MainCode }' AND " +
				$"organize_code_lev2_old = '{ param.DepartmetCode }' AND " +
				$"organize_code_lev3_old = '{ param.DivisionCode }' AND " +
				$"organize_code_lev4_old = '{ param.SectionCode }' AND " +
				$"organize_code_lev5_old = '{ param.JobCode }' ");
			if (op == null)
			{
				return null;
			}

			string organizeComma = op.Select(p => p.ORGANIZE_ID.ToString())
									 .Aggregate((_old, _new) => $"{_new},{_old}");

			var personal = await DB.GetObjectListAsync<VIEW_PERSONAL>(
				$"ORG_ID IN ({organizeComma}) AND USER_TYPE = 2");

			string personalComma = personal.Select(p => p.PERSONAL_ID.ToString())
									 .Aggregate((_old, _new) => $"{_new},{_old}");

			return personalComma;
		}


		[XpoAutoUpdate]
		[HttpPut("{id}")]
		//[AllowAnonymous]
		public async Task<StatusResult> Put(int id, [FromForm] CMS_PERSONAL value, [FromServices] ResourceUtility _resourceUtility)
		{
			DB.ConditionContext.RecordStatus = false;
			bool hasPersonal = await DB.GetXpQuery<CMS_PERSONAL>().AnyAsync(_ => _.PERSONAL_ID == id);

			if (!hasPersonal)
			{
				return StatusResult.Error("ไม่พบข้อมูลบุคลากร");
			}

			ADM_USER user = await DB.GetObjectAsync<ADM_USER>(
				$"PERSONAL_ID={id}");

			//CMS_ORGANIZE org = await DB.GetObjectByKeyAsync<CMS_ORGANIZE>(value.ORG_ID);

			//if (org == null)
			//{
			//	return StatusResult.Error("ไม่พบข้อมูลหน่วยงาน");
			//}

			if (value.UPLOAD_SIGNATURE_PICTURE != null)
			{
				ImageResource info = new ImageResource
				{
					File = value.UPLOAD_SIGNATURE_PICTURE,
					Destination = Path.Combine("img", "user",value.PERSONAL_ID.ToString()),
					Type = value.UPLOAD_SIGNATURE_PICTURE.ContentType.Contains("image/png") == true ? MagickFormat.Png : MagickFormat.Jpg,
					Name = "signature"
				};

				await _resourceUtility.SaveImageToResource(info);
				value.PERSONAL_SIGNATURE_PICTURE = info.FullPath;
			}

			if (value.UPLOAD_PICTURE != null)
			{
				ImageResource info = new ImageResource
				{
					ImageStream = value.UPLOAD_PICTURE.OpenReadStream(),
					Destination = Path.Combine("img", "user", DateTime.Today.ToString("yyyy-MM"),
						value.PERSONAL_ID.ToString()),
					Type = MagickFormat.Jpg,
					Name = "profile"
				};

				await _resourceUtility.SaveImageToResource(info);
				user.USER_PICTURE = info.FullPath;
			}


			bool isSaveUser = !(string.IsNullOrEmpty(value.USER_NAME) &&
			                    string.IsNullOrEmpty(value.NEW_PASSWORD) &&
			                    value.UPLOAD_PICTURE == null);

			//if (!string.IsNullOrEmpty(value.PERSONAL_CITIZEN_NUMBER))
			//{
			//	value.PERSONAL_CITIZEN_NUMBER = CryptoHelper
			//		.EncryptString(value.PERSONAL_CITIZEN_NUMBER,
			//			_setting.Keys.EncryptKey);
			//}

			if (isSaveUser)
			{

				if (user == null)
				{
					return StatusResult.Error("ไม่พบข้อมูลผู้ใช้งาน");
				}

				if (!string.IsNullOrEmpty(value.USER_NAME))
				{
					user.USER_NAME = value.USER_NAME;
				}

				if (!string.IsNullOrEmpty(value.NEW_PASSWORD))
				{
					if (string.IsNullOrEmpty(value.OLD_PASSWORD))
					{
						return StatusResult.Error("กรุณากรอกรหัสผ่านเก่า");
					}

					string oldPass = CryptoHelper.CreateSha256(value.OLD_PASSWORD);
					if (user.USER_PASSWORD == oldPass)
					{
						user.USER_PASSWORD = CryptoHelper.CreateSha256(value.NEW_PASSWORD);
					}
					else
					{
						return StatusResult.Error("รหัสผ่านไม่ตรงกับระบบ");
					}
				}

				DB.UpdateObject(user);
			}


			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		
    }
}

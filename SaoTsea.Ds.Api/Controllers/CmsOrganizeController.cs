using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmsOrganizeController : BetimesControllerBase
    {
		private ResourceUtility _resourceUtility;

		public CmsOrganizeController(
			ResourceUtility resourceUtility,
			ConditionContext conditionContext)
		{
			_resourceUtility = resourceUtility;
			conditionContext.MapFieldName(_ => _.SelfRootId, "ORGANIZE_ROOT_ID");
		}

		[LoadRole]
		[HttpGet]
		public async Task<StatusResult<VIEW_ORGANIZE[]>> Gets([FromQuery] FilterParam filter)
		{
			var user = UserInfo;
			var rootId = user.OrganizeRootId;
			var role = user.Roles.SingleOrDefault(_ => _.RoleId == filter.RoleId);

			if (role == null)
			{
				return StatusResult.Error("การทำงานถูกหยุด ไม่พบบทบาทของคุณ");
			}

			VIEW_ORGANIZE[] organizeInfo = null;

			if (role.RoleCode == "ROOT")
			{
				organizeInfo = await DB.GetXpQuery<VIEW_ORGANIZE>()
										  .Where(_ => _.DEL_FLAG == "N" && _.RECORD_STATUS == "A")
										  .OrderBy(_ => _.ORGANIZE_ID)
										  .ToArrayAsync();
			}
			else
			{
				organizeInfo = await DB.GetXpQuery<VIEW_ORGANIZE>()
										  .Where(_ => _.DEL_FLAG == "N" && _.RECORD_STATUS == "A" && _.ORGANIZE_ROOT_ID == rootId)
										  .OrderBy(_ => _.ORGANIZE_ID)
										  .ToArrayAsync();
			}


			return StatusResult.Ok(organizeInfo);
		}
		
		[HttpGet("{organizeId}")]
		public async Task<VIEW_ORGANIZE> GetByOrganizeId(int organizeId)
		{
			return await DB.GetObjectByKeyAsync<VIEW_ORGANIZE>(organizeId);
		}

		[HttpGet("app")]
		public async Task<List<OrganizeAppInfo>> GetApps()
		{
			var apps = await DB.StoredProcedure.GetsApp(UserInfo.UserId, UserInfo.OrganizeRootId);

			if (apps == null)
			{
				return null;
			}

			List<OrganizeAppInfo> info = new List<OrganizeAppInfo>(apps.Count);
			foreach (var item in apps.OrderBy(_ => _.APP_SEQ.Length).ThenBy(_ => _.APP_SEQ).ToArray())
			{
				//if (info.Exists(_ => _.APP_CODE == item.APP_CODE))
				//{
				//	continue;
				//}

				//int notiCount = 0;
				//คำสั่งการ
				//if (item.APP_CODE == "COMMAND")
				//{
				//	notiCount = await DB.GetXpQuery<CMD_COMMAND_ASSIGN>()
				//		.Where(_ => _.PERSON_ID == UserInfo.PersonalId
				//					&& (_.REPORT_STATUS != "R09" && _.REPORT_STATUS != "R05")
				//					&& _.RECORD_STATUS == "A"
				//					&& _.DEL_FLAG == "N")
				//		.CountAsync();
				//}
				info.Add(new OrganizeAppInfo()
				{
					APP_CODE = item.APP_CODE,
					APP_NAME = item.APP_NAME,
					APP_REMARK = item.APP_REMARK,
					APP_ICON = item.APP_ICON,
					APP_URL = item.APP_URL
					//NOTI_COUNT = notiCount
				});
			}


			return info;
		}

		[HttpGet("{orgId}/pki")]
		public Task<List<OrganizePkiResult>> GetPki(int orgId)
		{
			return DB.StoredProcedure.GetsOrganizePki(orgId);
		}

		[XpoFilter]
		[HttpPost("search")]
		public async Task<PagingResult<SearchOrganizeResult>> Search(SearchParam param)
		{
			return await DB.StoredProcedure.SearchOrganize(
				DB.ConditionContext.ToSql(param.Condition),
				param.Offset ?? 0,
				param.Length ?? 100);
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post([FromForm] CMS_ORGANIZE value)
		{
			await DB.CommitChangesAsync();

			if (value.UPLOAD_LOGO != null)
			{
				ImageResource info = new ImageResource
				{
					File = value.UPLOAD_LOGO,
					Destination = Path.Combine("img", "organize", "root_" + value.ORGANIZE_ROOT_ID),
					Type = MagickFormat.Png,
					Extension = "png",
					Name = "logo_" + value.ORGANIZE_ID
				};

				await _resourceUtility.SaveImageToResource(info);
				value.ORGANIZE_LOGO_PATH = info.FullPath;
			}

			switch (value.ORGANIZE_LEVEL_ID)
			{
				case 1:
					value.ORGANIZE_CODE_LEV1 = value.ORGANIZE_ID;
					break;
				case 2:
					value.ORGANIZE_CODE_LEV2 = value.ORGANIZE_ID;
					break;
				case 3:
					value.ORGANIZE_CODE_LEV3 = value.ORGANIZE_ID;
					break;
				case 4:
					value.ORGANIZE_CODE_LEV4 = value.ORGANIZE_ID;
					break;
				case 5:
					value.ORGANIZE_CODE_LEV5 = value.ORGANIZE_ID;
					break;
			}

			DB.UpdateObject(value);
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, [FromForm] CMS_ORGANIZE value)
		{
			if (value.UPLOAD_LOGO != null)
			{
				ImageResource info = new ImageResource
				{
					File = value.UPLOAD_LOGO,
					Destination = Path.Combine("img", "organize", "root_" + value.ORGANIZE_ROOT_ID),
					Type = MagickFormat.Png,
					Extension = "png",
					Name = "logo_" + value.ORGANIZE_ID
				};

				await _resourceUtility.SaveImageToResource(info);
				value.ORGANIZE_LOGO_PATH = info.FullPath;
			}

			switch (value.ORGANIZE_LEVEL_ID)
			{
				case 1:
					value.ORGANIZE_CODE_LEV1 = value.ORGANIZE_ID;
					break;
				case 2:
					value.ORGANIZE_CODE_LEV2 = value.ORGANIZE_ID;
					break;
				case 3:
					value.ORGANIZE_CODE_LEV3 = value.ORGANIZE_ID;
					break;
				case 4:
					value.ORGANIZE_CODE_LEV4 = value.ORGANIZE_ID;
					break;
				case 5:
					value.ORGANIZE_CODE_LEV5 = value.ORGANIZE_ID;
					break;
			}

			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

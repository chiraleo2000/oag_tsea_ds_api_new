using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdmUserRoleController : BetimesControllerBase
	{
		private AppSetting _settings;

		public AdmUserRoleController(AppSetting settings)
		{
			_settings = settings;
		}

        [LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_USER_ROLE[]> Gets()
		{
			return await DB.GetObjectListAsync<ADM_USER_ROLE>();
		}

        [LoadRole]
        [HttpGet("{roleId}/personal")]
        public async Task<StatusResult<RoleUser[]>> GetPersonalByRoleId([FromQuery] FilterParam filter, int roleId)
        {
            var user = UserInfo;
            var rootId = user.OrganizeRootId;
            var role = user.Roles.SingleOrDefault(_ => _.RoleId == roleId);

            if (role == null)
            {
                return StatusResult.Error("การทำงานถูกหยุด ไม่พบบทบาทของคุณ");
            }

            RoleUser[] userRole = null;
            if (role.RoleCode == "ROOT")
            {
                userRole = await DB.GetXpQuery<VIEW_USER_ROLE>()
                    .Where(_ => _.ROLE_ID == filter.RoleId && _.DEL_FLAG == "N" &&
                                _.APP_ID == filter.AppId && _.RECORD_STATUS == "A")
                    .OrderBy(_ => _.USER_ID)
                    .Select(_ => new RoleUser
                    {
                        USER_ROLE_ID = _.USER_ROLE_ID,
                        USER_ID = _.USER_ID,
                        PERSONAL_FULL_NAME = _.PERSONAL_FULL_NAME,
                        POSITION_NAME = _.POSITION_NAME,
                        ORG_NAME = _.ORG_NAME
                    })
                    .ToArrayAsync();
            }
            else
            {
                userRole = await DB.GetXpQuery<VIEW_USER_ROLE>()
                    .Where(_ => _.ROLE_ID == filter.RoleId && _.ORGANIZE_ROOT_ID == rootId &&
                                _.APP_ID == filter.AppId && _.DEL_FLAG == "N" &&
                                _.RECORD_STATUS == "A")
                    .OrderBy(_ => _.USER_ID)
                    .Select(_ => new RoleUser
                    {
                        USER_ROLE_ID = _.USER_ROLE_ID,
                        USER_ID = _.USER_ID,
                        PERSONAL_FULL_NAME = _.PERSONAL_FULL_NAME,
                        POSITION_NAME = _.POSITION_NAME,
                        ORG_NAME = _.ORG_NAME
                    })
                    .ToArrayAsync();
            }

            return StatusResult.Ok(userRole);
        }

        [HttpGet("module/permission")]
        public async Task<List<RoleMenuPriv>> GetModulePriv([FromQuery] FilterParam filter)
        {
            VIEW_ROLE_PRIV[] result = await DB.GetXpQuery<VIEW_ROLE_PRIV>()
                .Where(_ => _.ROLE_ID == filter.RoleId && _.APP_ID == filter.AppId)
                .OrderBy(_ => _.MODULE_SEQ.Length)
                .ThenBy(_ => _.MODULE_SEQ)
                .ToArrayAsync();

            List<RoleMenuPriv> rolePrivList = new List<RoleMenuPriv>();
            foreach (var menuGroup in result.GroupBy(_ => _.MODULE_ID))
            {
                VIEW_ROLE_PRIV curMenu = menuGroup.First();
                RoleMenuPriv rolePriv = new RoleMenuPriv
                {
                    MODULE_PARENT_ID = curMenu.MODULE_PARENT_ID,
                    MODULE_NAME = curMenu.MODULE_NAME,
                    MODULE_ID = curMenu.MODULE_ID,
                    MODULE_ICON = curMenu.MODULE_ICON,
                    MODULE_LEVEL = curMenu.MODULE_LEVEL,
                    MODULE_SEQ = curMenu.MODULE_SEQ,
                    PERMISSION = menuGroup.Select(_ => new RoleMenuPrivPermission
                    {
                        ROLE_PRIV_ID = _.ROLE_PRIV_ID,
                        MODULE_PRIV_ID = _.MODULE_PRIV_ID,
                        PERMISSION_ID = _.PERMISSION_ID,
                        PERMISSION_NAME = _.PERMISSION_NAME,
                        PRIV_FLAG = _.PRIV_FLAG
                    }).ToArray()
                };
                rolePrivList.Add(rolePriv);
            }

            return rolePrivList;
        }

        [XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(ADM_USER_ROLE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_USER_ROLE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AdmRoleInfoController : BetimesControllerBase
	{
		private AppSetting _settings;

		public AdmRoleInfoController(AppSetting settings)
		{
			_settings = settings;
		}

		[LoadRole]
		[HttpGet]
		[XpoFilter]
        public async Task<ADM_ROLE_INFO[]> Gets()
		{
			ADM_ROLE_INFO[] roleInfd = null;
			roleInfd = await DB.GetObjectListAsync<ADM_ROLE_INFO>();
			return roleInfd?.OrderBy(_ => _.ROLE_SEQ).ThenBy(_ => _.ROLE_SEQ).ToArray();
		}

		[LoadRole]
		[HttpGet("{roleId}")]
		[XpoFilter]
		public async Task<ADM_ROLE_INFO> GetById(int roleId)
		{
			return await DB.GetObjectByKeyAsync<ADM_ROLE_INFO>(roleId);
		}

		[HttpPost("permission/create")]
		public async Task<StatusResult> Post(CreateRolePermisParam param)
		{
			return await DB.StoredProcedure.CreateRolePermission(param.RoleId, param.AppId);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<StatusResult> Post(RoleUserParam value)
		{
			//เพิ่มข้อมูลสิทธิ์

            var xpoRoleInfo = DB.InsertObject(value.RoleInfo);
            await DB.CommitChangesAsync();

            //เพิ่มสิทธิ์ให้กับผู้ใช้
            foreach (var user in value.UserRole)
            {
                user.ROLE_ID = xpoRoleInfo.ROLE_ID;
                DB.InsertObject(user);
            }

            await DB.CommitChangesAsync();
            return StatusResult.Ok();
		}

		[HttpPut("{id}")]
		[AllowAnonymous]
		public async Task<StatusResult> Put(int id, RoleUserParam value)
		{

			
            //แก้ไขข้อมูลสิทธิ์
            var xpoRoleInfo = DB.UpdateObject(value.RoleInfo);

            //เพิ่มสิทธิ์ให้กับผู้ใช้
            foreach (var user in value.UserRole)
            {
                if (user.USER_ROLE_ID == 0)
                {
                    user.ROLE_ID = xpoRoleInfo.ROLE_ID;
                    DB.InsertObject(user);
                }
                else
                {
                    DB.UpdateObject(user);
                }
            }

            await DB.CommitChangesAsync();
            return StatusResult.Ok();
		}
	}
}

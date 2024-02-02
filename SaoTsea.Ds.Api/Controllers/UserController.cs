using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly TokenFactory _tokenFactory;
		private readonly DBHandlerCore _db;
		private readonly AppSetting _settings;

        public UserController(
			TokenFactory tokenFactory,
			DBHandlerCore dbHandler,
			AppSetting settings)
		{
			_tokenFactory = tokenFactory;
			_db = dbHandler;
			_settings = settings;
		}

        [Authorize]
        [HttpGet("me")]
        public StatusResult<UserPayload> GetUserProfile([FromServices] UserPayload _payload)
        {
            return StatusResult.Ok(_payload);
        }

		[Authorize]
		[HttpGet("menus")]
		public async Task<StatusResult<List<Menu>>> GetUserMenus(
	    [FromQuery] int roleId, [FromQuery] string appCode)
		{
			List<Menu> internalMenu = await _db.StoredProcedure.GetsMenu(roleId, appCode);

            if (internalMenu == null)
            {
				return StatusResult.NotFound("ไม่พบข้อมูลเมนู");
            }


			List<Menu> menu = new List<Menu>();
			foreach (var menuGroup in internalMenu.GroupBy(_ => _.MODULE_CODE))
			{
				Menu curMenu = menuGroup.First();
				MenuPermission permission = new MenuPermission();
				foreach (var m in menuGroup)
				{
					switch (m.PERMISSION_CODE)
					{
						case "001":
							permission.ADD = true;
							break;
						case "002":
							permission.EDIT = true;
							break;
						case "003":
							permission.DELETE = true;
							break;
						case "004":
							permission.VIEW = true;
							break;
						case "005":
							permission.UPLOAD = true;
							break;
						case "006":
							permission.DOWNLOAD = true;
							break;
					}
				}

				curMenu.PERMISSION_CODE = null;
				curMenu.PERMISSION = permission;
				menu.Add(curMenu);
			}

			return StatusResult.Ok(menu);
		}


	}
}

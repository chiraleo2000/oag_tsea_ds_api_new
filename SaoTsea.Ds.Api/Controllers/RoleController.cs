using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : BetimesControllerBase
	{
		private readonly DBHandlerCore _db;
		private static ConcurrentDictionary<string, object> _dataCache =
			new ConcurrentDictionary<string, object>();
		public RoleController(DBHandlerCore db)
		{
			_db = db;
		}

		[HttpGet("{appcode}")]
        public async Task<IEnumerable<RoleInfo>> GetUserRole(string appCode)
		{
            string key = "user_role_" + UserInfo.UserId;
			List<UserRoleEntity> user_list = await _db.StoredProcedure.GetRoleUser(UserInfo.UserId, appCode);
			if (!user_list.Any())
			{
				return null;
			}
            ///NOTE : process ใหม่เพื่อเช็คว่าถ้ามีบทบาทที่เป็น ROLE_ คือมาจาก sso
            List <RoleInfo> roles = null;
            roles = user_list.GroupBy(_ => _.AppCode).Select(user => new RoleInfo
            {
                AppCode = user.First().AppCode,
                RoleId = user.First().RoleId,
                RoleCode = user.First().RoleCode,
                RoleName = user.First().RoleName,
                OrgRefId = user.First().RoleOrganizeId,
                OrgLevel = user.First().OrgLv
            }).ToList();
            return roles;
			//return await dataAccess.GetUserRolesAsync(UserInfo.UserId, false);
		}

		static bool IsValidCardId(string cardId)
		{
			string pattern = @"^\d{13}$"; // 13 digits
			return Regex.IsMatch(cardId, pattern);
		}
	}
}

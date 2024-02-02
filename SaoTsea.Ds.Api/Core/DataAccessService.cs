using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.Extensions.DependencyInjection;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
	public class DataAccessService
	{
		private static ConcurrentDictionary<string, object> _dataCache =
			new ConcurrentDictionary<string, object>();

		private IServiceProvider _sp;

		public DataAccessService(IServiceProvider sp)
		{
			_sp = sp;
		}


		public async Task<IEnumerable<RoleInfo>> GetUserRolesAsync(int userId, bool loadFromCache = true)
		{
			string key = "user_role_" + userId;
			//if (loadFromCache && _dataCache.TryGetValue(key, out object value))
			//{
			//	return Task.FromResult((IEnumerable<RoleInfo>) value).Result;
			//}
			
			using var scope = _sp.CreateScope();
			var uof = scope.ServiceProvider.GetService<BetimesUntiOfWork>();
			var result = await uof.Query<VIEW_USER_ROLE_ALL>()
				.Where(_ => _.USER_ID == userId)
				.ToArrayAsync();

			//var result = await uof.Query<VIEW_USER_ROLE>()
			//	.Where(_ => _.USER_ID == userId && _.RI_RECORD_STATUS == "A" &&
			//				_.RECORD_STATUS == "A" &&
			//				_.DEL_FLAG == "N")
			//	.ToArrayAsync();
			if (!result.Any())
			{
				return null;
			}

			IEnumerable<RoleInfo> roles = result.Select(_ => new RoleInfo
			{
				AppCode = _.APP_CODE,
				RoleId = _.ROLE_ID,
				RoleCode = _.ROLE_CODE,
				RoleName = _.ROLE_NAME,
				OrgRefId = _.ROLE_ORGANIZE_ID,
				OrgLevel = _.ORG_LV
			});

			_dataCache.AddOrUpdate(key, roles, (k, o)=> roles);

			return roles;
		}
	}
}

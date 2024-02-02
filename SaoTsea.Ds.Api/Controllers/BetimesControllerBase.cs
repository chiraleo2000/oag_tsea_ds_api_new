using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Authorize]
	public class BetimesControllerBase : ControllerBase
	{
		private DBHandlerCore _db;
		private UserPayload _user;
		public DBHandlerCore DB => _db ??= HttpContext?.RequestServices.GetService<DBHandlerCore>();
		public UserPayload UserInfo => _user ??= HttpContext?.RequestServices.GetService<UserPayload>();
	}
}
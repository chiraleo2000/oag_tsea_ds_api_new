using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
	public class TokenBearerEvents : JwtBearerEvents
	{
		private UserPayload _userInfo;
		private DBHandlerCore _db;
		private DataAccessService _dataAccess;
		private readonly UserProfileStore _profileStore;
		private readonly ILogger<TokenBearerEvents> _logger;

		public TokenBearerEvents(UserPayload userInfo, DBHandlerCore db, DataAccessService dataAccess, UserProfileStore profileStore, ILogger<TokenBearerEvents> logger)
		{
			_userInfo = userInfo;
			_db = db;
			_dataAccess = dataAccess;
			_profileStore = profileStore;
			_logger = logger;
		}

		//public override async Task TokenValidated(TokenValidatedContext context)
		//{
		//	await base.TokenValidated(context);

		//	ClaimsPrincipal userPrincipal = context.Principal;
		//	Type contentType = _userInfo.GetType();
		//	foreach (Claim c in userPrincipal.Claims)
		//	{
		//		var property = contentType.GetProperty(c.Type);
		//		if (property != null)
		//		{
		//			TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
		//			property.SetValue(_userInfo, converter.ConvertFromString(c.Value));
		//		}
		//	}

		//	if (!context.HttpContext.Request.Path.StartsWithSegments("/api/role"))
		//	{
		//		_userInfo.Roles = await _dataAccess.GetUserRolesAsync(_userInfo.UserId);
		//	}
		//}

		public override async Task TokenValidated(TokenValidatedContext context)
		{
			await base.TokenValidated(context);
            try
			{
				///TODO : add profile to payLoad
				await _profileStore.LoadUserProfileAsync(context.Principal);
            }
			catch (Exception e)
			{
				_logger.LogError(e, "Error Trigger :");
				context.Fail(e);
			}
		}
	}
}

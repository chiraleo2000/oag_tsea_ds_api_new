using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DevExpress.Xpo;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
	public class UserProfileStore
	{
		private readonly DBHandlerCore _db;
		private readonly UserPayload _userPayload;

        public UserProfileStore(DBHandlerCore db, UserPayload userPayload)
		{
			_db = db;
			_userPayload = userPayload;
		}

		//public async Task<UserPayload> GetUserProfileAsync(int userId)
		//{
		//	var user = await _db.GetXpQuery<ADM_USER>().FirstOrDefaultAsync(_ => _.USER_ID == userId);
		//	if (user == null)
		//	{
		//		return null;
		//	}

		//	var personal = await _db.GetObjectByKeyAsync<VIEW_PERSONAL>(user.PERSONAL_ID);
		//	if (personal == null)
		//	{
		//		return null;
		//	}

		//	return new UserPayload
		//	{
		//		UserId = user.USER_ID,
		//		UserName = user.USER_NAME,
		//		PersonalId = user.PERSONAL_ID,
		//		FullNameTH = personal.PERSONAL_FULL_NAME,
		//		FirstNameTH = personal.PERSONAL_FNAME_THA,
		//		LastNameTH = personal.PERSONAL_LNAME_THA,
		//		PositionId = personal.POSITION_ID,
		//		PositionNameTH = personal.POSITION_NAME,
		//		OrganizeId = personal.ORG_ID,
		//		OrganizeNameTH = personal.ORGANIZE_NAME_THA,
		//		ImageUrl = user.USER_PICTURE,
		//		OrganizeLevel = personal.ORGANIZE_LEVEL,
		//		LastAccessDateTime = user.USER_LOGIN_DATE,
		//		UserType = personal.PERSONAL_TYPE_ID,
		//		LoginType = user.USER_LOGIN_FLAG,
		//		OrganizeRootId = personal.ORGANIZE_ROOT_ID
		//	};
		//}



		public async Task<UserPayload> GetUserProfileAsync(string userName)
		{
			var user = await _db.GetXpQuery<ADM_USER>().FirstOrDefaultAsync(_ => _.USER_NAME == userName);
			if (user == null)
			{
				return null;
			}

			var personal = await _db.GetXpQuery<VIEW_PERSONAL>().FirstOrDefaultAsync(_ => _.PERSONAL_ID == user.PERSONAL_ID); ;// await _db.GetObjectByKeyAsync<VIEW_PERSONAL>(user.PERSONAL_ID);
			if (personal == null)
			{
				return null;
			}

			return new UserPayload
			{
				UserId = user.USER_ID,
				UserName = user.USER_NAME,
				PersonalId = user.PERSONAL_ID,
				FullNameTH = personal.PERSONAL_FULL_NAME,
				FirstNameTH = personal.PERSONAL_FNAME_THA,
				LastNameTH = personal.PERSONAL_LNAME_THA,
				PositionId = personal.POSITION_ID,
				PositionNameTH = personal.POSITION_NAME,
				OrganizeId = personal.ORG_ID,
				OrganizeNameTH = personal.ORGANIZE_NAME_THA,
				ImageUrl = user.USER_PICTURE,
				OrganizeLevel = personal.ORGANIZE_LEVEL,
				LastAccessDateTime = user.USER_LOGIN_DATE,
				UserType = personal.PERSONAL_TYPE_ID,
				LoginType = user.USER_LOGIN_FLAG,
				OrganizeRootId = personal.ORGANIZE_ROOT_ID
			};
		}

		public async Task LoadUserProfileAsync(ClaimsPrincipal principal)
		{
			var ialClaim = principal.FindFirst("ial");
			var aalClaim = principal.FindFirst("aal");

            var claimUserName = principal.FindFirst(ClaimTypes.GivenName);

            if (claimUserName == null)
            {
                throw new Exception("ไม่พบข้อมูล Username ใน claim");
            }

			var payload = await GetUserProfileAsync(claimUserName.Value);
			if (payload == null)
			{
				throw new Exception("ไม่พบข้อมูลบุคคล");
			}

			Type contentType = payload.GetType();
			Type targetType = _userPayload.GetType();
			foreach (var c in contentType.GetProperties())
			{
				object v = c.GetValue(payload);
				if (v != null)
				{
					targetType.GetProperty(c.Name).SetValue(_userPayload, v);
				}
			}

			if (ialClaim != null)
			{
				payload.Ial = float.Parse(ialClaim.Value);
			}

			if (aalClaim != null)
			{
				payload.Aal = float.Parse(aalClaim.Value);
			}
		}

		//public static string GetUserId(ClaimsPrincipal principal)
		//{

		//	var claimsIdentity = (ClaimsIdentity)principal.Identity;
		//	var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimsIdentity.DefaultNameClaimType);
		//	return claim.Value;
		//}


		public async Task<UserPayload> GetUserProfileAsync(ADM_USER user)
		{
			//var personal = await _db.GetObjectByKeyAsync<VIEW_PERSONAL>(user.PERSONAL_ID);
			var personal = await _db.GetXpQuery<VIEW_PERSONAL>().FirstOrDefaultAsync(_ => _.PERSONAL_ID == user.PERSONAL_ID);
			if (personal == null)
			{
				return null;
			}

			return new UserPayload
			{
				UserId = user.USER_ID,
				UserName = user.USER_NAME,
				PersonalId = user.PERSONAL_ID,
				FullNameTH = personal.PERSONAL_FULL_NAME,
				FirstNameTH = personal.PERSONAL_FNAME_THA,
				LastNameTH = personal.PERSONAL_LNAME_THA,
				PositionId = personal.POSITION_ID,
				PositionNameTH = personal.POSITION_NAME,
				OrganizeId = personal.ORG_ID,
				OrganizeNameTH = personal.ORGANIZE_NAME_THA,
				ImageUrl = user.USER_PICTURE,
				OrganizeLevel = personal.ORGANIZE_LEVEL,
				LastAccessDateTime = user.USER_LOGIN_DATE,
				UserType = personal.PERSONAL_TYPE_ID,
				LoginType = user.USER_LOGIN_FLAG,
				OrganizeRootId = personal.ORGANIZE_ROOT_ID,
				CitizenNumber = personal.PERSONAL_CITIZEN_NUMBER
			};
		}
	}
}

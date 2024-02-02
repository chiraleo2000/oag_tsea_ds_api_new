using System;
using System.Collections.Generic;
using SaoTsea.Ds.Api.Core;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class UserPayload
	{
		public int UserId { get; set; } = -1;
		public int UserType { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public int PersonalId { get; set; }
		public float? UserIal { get; set; }
		public string FullNameTH { get; set; }
		public string FirstNameTH { get; set; }
		public string MiddleNameTH { get; set; }
		public string LastNameTH { get; set; }
		public int? PositionId { get; set; }
		public string PositionNameTH { get; set; }
		public int OrganizeId { get; set; }
		public int OrganizeLevel { get; set; }
		public int OrganizeRootId { get; set; }
		public string OrganizeNameTH { get; set; }
		public string ImageUrl { get; set; }
		public DateTime? LastAccessDateTime { get; set; }
		public int PersonalType { get; set; }
		public string CitizenNumber { get; set; }
		public DateTime? BirthDate { get; set; }
		public string Title { get; set; }
		public int? TitleId { get; set; }
		public int? RefRegisterId { get; set; }

		public int? ProvinceId { get; set; }
		public int? DistrictId { get; set; }
		public int? SubDistrictId { get; set; }
		public int? PostCode { get; set; }
		public int? NationId { get; set; }

		public string UserMobile { get; set; }

		public string AddressNo { get; set; }
		public string AddressMoo { get; set; }
		public string AddressSoi { get; set; }
		public string AddressBuilding { get; set; }
		public string AddressFloor { get; set; }
		public string AddressStreet { get; set; }
		public string SecurityFlag { get; set; }
		public string SecurityType { get; set; }

		public string LoginType { get; set; }
		public float Ial { get; set; }
		public float Aal { get; set; }

		[ExcludeFromResultSet] public IEnumerable<RoleInfo> Roles { get; set; }
	}
}

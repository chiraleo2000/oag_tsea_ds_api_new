using System;
using System.Collections.Generic;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class OIDCUserInfo
	{
		public string id { get; set; }
		public DateTime created_at { get; set; }
		public DateTime? updated_at { get; set; }
		public string uuid { get; set; }
		public UserId user_id { get; set; }
		public Email email { get; set; }
		//public InternetAddress internet_address { get; set; }
		public PersonId person_id { get; set; }
		public NameTh name_th { get; set; }
		public NameEn name_en { get; set; }
		public Dob dob { get; set; }
		public Sex sex { get; set; }
		public Nationality nationality { get; set; }
		public Phone mobileno { get; set; }
		public Ial ial { get; set; }
		public Aal aal { get; set; }
		public Active active { get; set; }
		public int permission { get; set; }
		public ResidentialStatus residentialstatus { get; set; }
		public RegAdd regadd { get; set; }
		public Pid pid { get; set; }
		public PartialPid partialpid { get; set; }
		public OIDCImposination imposination { get; set; }

		// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
		public class UserId
		{
			public string value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Email
		{
			public string value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Pid
		{
			public string value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class PartialPid
		{
			public string value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class RegAdd
		{
			public string type { get; set; }
			public HouseNo houseno { get; set; }
			public VillageNo villageno { get; set; }
			public Lane lane { get; set; }
			public Street street { get; set; }
			public SubDistrict subdistrict { get; set; }
			public District district { get; set; }
			public Province province { get; set; }
			public Postal postal { get; set; }
			public Country country { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class ResidentialStatus
		{
			public string code { get; set; }
			public string desc { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class VerifiedAt
		{
			public DateTime value { get; set; }
		}

		public class InternetAddress
		{
			public Email email { get; set; }
			public VerifiedAt verified_at { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class CitizenId
		{
			public string value { get; set; }
		}

		public class PassportNo
		{
			public string value { get; set; }
		}

		public class IssueCountry
		{
			public string code { get; set; }
			public string description { get; set; }
		}

		public class PersonId
		{
			public CitizenId citizen_id { get; set; }
			public PassportNo passport_no { get; set; }
			public IssueCountry issue_country { get; set; }
			public string type { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Prefix
		{
			public string value { get; set; }
		}

		public class FirstName
		{
			public string value { get; set; }
		}

		public class MiddleName
		{
			public string value { get; set; }
		}

		public class LastName
		{
			public string value { get; set; }
		}

		public class NameTh
		{
			public Prefix prefix { get; set; }
			public FirstName first_name { get; set; }
			public MiddleName middle_name { get; set; }
			public LastName last_name { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class NameEn
		{
			public Prefix prefix { get; set; }
			public FirstName first_name { get; set; }
			public MiddleName middle_name { get; set; }
			public LastName last_name { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Dob
		{
			public string value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Sex
		{
			public string code { get; set; }
			public string desc { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Nationality
		{
			public string code { get; set; }
			public string desc { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Sequence
		{
			public int value { get; set; }
		}

		public class Building
		{
			public string value { get; set; }
		}

		public class RoomNo
		{
			public string value { get; set; }
		}

		public class Floor
		{
			public string value { get; set; }
		}

		public class VillageNo
		{
			public string value { get; set; }
		}

		public class HouseNo
		{
			public string value { get; set; }
		}

		public class Moo
		{
			public string value { get; set; }
		}

		public class Alley
		{
			public string value { get; set; }
		}

		public class Lane
		{
			public string value { get; set; }
		}

		public class Street
		{
			public string value { get; set; }
		}

		public class SubDistrict
		{
			public string value { get; set; }
		}

		public class District
		{
			public string value { get; set; }
		}

		public class Province
		{
			public string value { get; set; }
		}

		public class Code
		{
			public string value { get; set; }
		}

		public class Postal
		{
			public string value { get; set; }
		}

		public class Phone
		{
			public string value { get; set; }
			public Prefix prefix { get; set; }
			public AreaCode area_code { get; set; }
			public Nbr nbr { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Country
		{
			public string code { get; set; }
			public string desc { get; set; }
		}

		public class RegisterAddress
		{
			public string type { get; set; }
			public Sequence sequence { get; set; }
			public Building building { get; set; }
			public RoomNo room_no { get; set; }
			public Floor floor { get; set; }
			public VillageNo village_name { get; set; }
			public HouseNo no { get; set; }
			public Moo moo { get; set; }
			public Alley alley { get; set; }
			public Lane soi { get; set; }
			public Street road { get; set; }
			public SubDistrict tumbol { get; set; }
			public District amphur { get; set; }
			public Province province { get; set; }
			public Code code { get; set; }
			public Postal zipcode { get; set; }
			public Phone phone { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}
		

		public class AreaCode
		{
			public string value { get; set; }
		}

		public class Nbr
		{
			public string value { get; set; }
		}

		public class Ial
		{
			public double value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Aal
		{
			public double value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}

		public class Active
		{
			public bool value { get; set; }
			public string classification { get; set; }
			public int source { get; set; }
			public string lastupdated { get; set; }
		}
	}


	public class OIDCUserSearchInfo
	{
		public List<OIDCUserInfo> entities { get; set; }
	}
	public class OIDCInternetAddress
	{
		public OIDCValue email { get; set; }
	}

	public class OIDCPersonal
	{
		public OIDCValue citizen_id { get; set; }
		public OIDCValue passport_no { get; set; }
	}

	public class OIDCUser
	{
		public string value { get; set; }
		public string classification { get; set; }
		public int source { get; set; }
		public DateTime lastupdated { get; set; }
	}

	public class OIDCName
	{
		public OIDCValue prefix { get; set; }
		public OIDCValue first_name { get; set; }
		public OIDCValue middle_name { get; set; }
		public OIDCValue last_name { get; set; }
	}

	public class OIDCRegisterAddress
	{
		public OIDCValue tumbol { get; set; }
		public OIDCValue amphur { get; set; }
		public OIDCValue province { get; set; }
		public OIDCValue road { get; set; }
	}

	public class OIDCPhone
	{
		public OIDCValue prefix { get; set; }
		public OIDCValue areacode { get; set; }
		public OIDCValue nbr { get; set; }
	}

	public class OIDCImposination
	{
		public string user_id { get; set; }
		public string user_desc { get; set; }
	}

	public class OIDCValue
	{
		public string code { get; set; } = null;
		public string desc { get; set; } = null;
		public string value { get; set; } = "";
	}
}

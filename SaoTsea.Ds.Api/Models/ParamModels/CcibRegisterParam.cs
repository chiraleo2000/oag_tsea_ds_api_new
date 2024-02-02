using System;
using System.Collections.Generic;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class CcibRegisterParam
	{
		public string AgainPassword {get; set;}
		public int ProvinceId {get; set;}
		public int DistictId {get; set;}
		public int SubDistrictId {get; set;}
		public string NewPassword {get; set;}
		public string PersonalAddress {get; set;}
		public DateTime PersonalBirthDate {get; set;}
		public string PersonalCitizenNumber {get; set;}
		public string PersonalEmail {get; set;}
		public string PersonalFnameTh {get; set;}
		public byte PersonalGender {get; set;}
		public string PersonalLnameTh {get; set;}
		public string PersonalTelNo {get; set;}
		public string PostcodeCode {get; set;}
		public int TitleId {get; set;}
		public List<FileBase64> UploadPictureBase64 {get; set;}
		public string UserName {get; set;}	}
}

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class PersonalEdoc
	{
		public int PERSONAL_PKI_ID {get; set;}
		public int PERSONAL_ID {get; set;}
		public string PKI_PATH {get; set;}
		public string PKI_SIGNATURE {get; set;}
		public int PKI_TYPE {get; set;}
		public string RECORD_STATUS { get; set; }
		public string SIGNATURE_IMAGE_BASE64 { get; set; }
	}
}

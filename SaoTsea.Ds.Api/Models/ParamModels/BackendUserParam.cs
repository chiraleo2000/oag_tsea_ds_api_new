using System;
using System.IO;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class BackendUserParam
	{
		public string NEW_PASSWORD { get; set; }
		public string OLD_PASSWORD { get; set; }
		public string USER_NAME { get; set; }
		public Stream UPLOAD_SIGNATURE_PICTURE { get; set; }
		public Stream UPLOAD_PICTURE { get; set; }
		public bool SYNC_USER_CAMUNDA { get; set; } = true;
		public int PERSONAL_ID { get; set; }
		public string PERSONAL_CODE { get; set; }
		public int TITLE_ID { get; set; }
		public string PERSONAL_FNAME_THA { get; set; }
		public string PERSONAL_LNAME_THA { get; set; }
		public DateTime PERSONAL_START_DATE { get; set; }
		public DateTime PERSONAL_BIRTH_DATE { get; set; }
		public DateTime PERSONAL_LEAVE_DATE { get; set; }
		public string PERSONAL_SIGNATURE_PICTURE { get; set; }
		public int PERSONAL_TYPE_ID { get; set; }
		public int? POSITION_ID { get; set; }
		public string POSITION_NAME { get; set; }
		public int POSITION_MNG_ID { get; set; }
		public string POSITION_MNG_NAME { get; set; }
		public int POSITION_MNG_LEVEL { get; set; }
		public int ORG_ID { get; set; }
		public string ORG_NAME { get; set; }
		public string PERSONAL_TEL_NO { get; set; }
		public string PERSONAL_NATIONALITY { get; set; }
		public string PERSONAL_RACE { get; set; }
		public string PERSONAL_TEL_HOME { get; set; }
		public string PERSONAL_TEL_POSITION { get; set; }
		public string PERSONAL_ADDRESS_HOME_REGISTER { get; set; }
		public string PERSONAL_ACCIDENCE_TEL { get; set; }
		public string PERSONAL_STATUS { get; set; }
		public string PERSONAL_CITIZEN_NUMBER { get; set; }
		public string PERSONAL_ADDRESS { get; set; }
		public int PROVINCE_ID { get; set; }
		public int DISTICT_ID { get; set; }
		public int SUB_DISTICT_ID { get; set; }
		public int POST_CODE { get; set; }
		public int HOME_REGISTER_PROVINCE_ID { get; set; }
		public int HOME_REGISTER_DISTICT_ID { get; set; }
		public int HOME_REGISTER_SUB_DISTICT_ID { get; set; }
		public int HOME_REGISTER_POST_CODE { get; set; }
		public string ACCIDENCE_TEL { get; set; }
		public string ACCIDENCE_ADDRESS { get; set; }
		public int ACCIDENCE_PROVINCE { get; set; }
		public int ACCIDENCE_DISTICT { get; set; }
		public int ACCIDENCE_SUB_DISTICT { get; set; }
		public int ACCIDENCE_POST_CODE { get; set; }
		public string PERSONAL_RELIGION { get; set; }
		public byte PERSONAL_GENDER { get; set; }
		public string PERSONAL_EMAIL { get; set; }
		public int PERSONAL_SALARY { get; set; }
		public string PERSONAL_WORK_ADDRESS { get; set; }
		public string PERSONAL_PICTURE { get; set; }
		public string ACCIDENCE_PERSON { get; set; }
		public string ACCIDENCE_RELATION { get; set; }
		public string HOME_REGISTER_ADDRESS { get; set; }
	}
}

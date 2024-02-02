using System;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
    public class SearchPostCode
    {
		public int? POSTCODE_ID { get; set; }
		public int? POSTCODE_CODE { get; set; }
		public int? PROVINCE_ID { get; set; }
		public int? DISTRICT_ID { get; set; }
		public int? SUB_DISTRICT_ID { get; set; }
		public string RECORD_STATUS { get; set; }
		public string DEL_FLAG { get; set; }
		public int? CREATE_USER_ID { get; set; }
		public DateTime? CREATE_DATE { get; set; }
		public int? UPDATE_USER_ID { get; set; }
		public DateTime? UPDATE_DATE { get; set; }
		public string SUB_DISTRICT_NAME_THA { get; set; }
	}
}

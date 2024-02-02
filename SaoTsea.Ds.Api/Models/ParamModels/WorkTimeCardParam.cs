using System;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class WorkTimeCardParam
	{
		public IFormFile UPLOAD_IMAGE { get; set; }
		public int ORG_ROOT_ID { get; set; }
		public int PERSON_ID { get; set; }
		public string TIMECARD_PLACE_TYPE { get; set; }
		public string TIMECARD_PLACE_TYPE_OTH { get; set; }
		public string TIMECARD_TYPE { get; set; }
		public DateTime TIMECARD_TIMESTAMP { get; set; }
		public float TIMECARD_LAT { get; set; }
		public float TIMECARD_LONG { get; set; }
		public string TIMECARD_PLACE_DESC { get; set; }
		public string TIMECARD_IMAGE { get; set; }
		public string TIMECARD_REMARK { get; set; }
		public string WFH_HEALTH_CODE { get; set; }
		public string WFH_HEALTH_FLAG { get; set; }
		public string WFH_HEALTH_01 { get; set; }
		public string WFH_HEALTH_02 { get; set; }
		public string WFH_HEALTH_03 { get; set; }
		public string WFH_HEALTH_04 { get; set; }
		public string WFH_HEALTH_05 { get; set; }
		public string WFH_HEALTH_06 { get; set; }
		public string WFH_HEALTH_07 { get; set; }
		public string WFH_HEALTH_08 { get; set; }
		public string WFH_HEALTH_09 { get; set; }
		public string WFH_HEALTH_10 { get; set; }
		public string WFH_HEALTH_DESC { get; set; }
		public double WFH_HEALTH_TEMP { get; set; }

		/** ใช้สำหรับส่งไปให้ Queue ฝั่ง NG ไม่ต้องส่งมา */
		public string UPLOAD_IMAGE_BASE64 { get; set; }

		public int USER_ID { get; set; }
	}
}

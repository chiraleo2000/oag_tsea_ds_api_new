using System;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class FilterProcInstTracking
    {
        public int INST_ID { get; set; }
        public int PERSONAL_ID { get; set; }
        public int ORG_ID { get; set; }
        public string TRACKING_CODE { get; set; }
        public string FORM_NAME { get; set; }
        public string FORM_CODE { get; set; }
        public string FLOW_NAME { get; set; }
        public string ORGANIZE_NAME_THA { get; set; }
        public string PERSONAL_CITIZEN_NUMBER { get; set; }
        public string PERSONAL_FULL_NAME { get; set; }
        public string STATUS_NAME { get; set; }
        public string STATUS_CODE { get; set; }
        public string GROUP_STATUS_CODE { get; set; }
        public string GROUP_STATUS_NAME { get; set; }
        public string DEL_FLAG { get; set; }
        public int CREATE_USER_ID { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int? UPDATE_USER_ID { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string CREATE_DATE_TH { get; set; }
        public string UPDATE_DATE_TH { get; set; }
        public string USE_DATE_SEARCH { get; set; } = "";
        public string ID_CARD { get; set; }
        public DateTime START_DATE_TIME { get; set; }
        public DateTime END_DATE_TIME { get; set; }
        public bool SORT_TABLE { get; set; } = false;
        public bool SORT_ASCENDING { get; set; } = true;
        public string SORT_COLUMN_NAME { get; set; }
        public int Offset { get; set; } = 0;
        public int Length { get; set; } = 10;
    }
}

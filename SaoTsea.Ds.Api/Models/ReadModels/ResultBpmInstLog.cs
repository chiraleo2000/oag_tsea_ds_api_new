using System;
using Newtonsoft.Json.Linq;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
    public class ResultBpmInstLog
    {
        public int INST_LOG_ID { get; set; }
        public int INST_ID { get; set; }
        public int FLOW_ID { get; set; }
        public int FORM_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public int PERSONAL_ID { get; set; }
        public int ORG_ID { get; set; }
        public string TRACKING_CODE { get; set; }
        public string STATUS_CODE { get; set; }
        public string GROUP_STATUS_CODE { get; set; }
        public int DATA_ID { get; set; }
        public string SYSTEM_CODE { get; set; }
        public string DOCUMENT_ID { get; set; }
        public string WF_INSTANCE_ID { get; set; }
        public string WF_DEFINITION_ID { get; set; }
        public string REMARK { get; set; }
        public char RECORD_STATUS { get; set; }
        public char DEL_FLAG { get; set; }
        public int CREATE_USER_ID { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int UPDATE_USER_ID { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public string FORM_NAME { get; set; }
        public string FLOW_NAME { get; set; }
        public string PERSONAL_FULL_NAME { get; set; }
        public string ORGANIZE_NAME_THA { get; set; }
        public int ORGANIZE_LEVEL { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string STATUS_NAME { get; set; }
        public string FORM_IO_ID { get; set; }
        public int? OFFICER_ID { get; set; }
        public string OFFICER_FULL_NAME { get; set; }
        public string TASK_DOCUMENT_ID { get; set; }
        public string TASK_FORM_CODE { get; set; }
        public string OFFICER_PROGRESS_FULL_NAME { get; set; }
        public string FORM_CONFIG_ID { get; set; }
        public JObject SUBMISSION_JSON { get; set; }

    }
}

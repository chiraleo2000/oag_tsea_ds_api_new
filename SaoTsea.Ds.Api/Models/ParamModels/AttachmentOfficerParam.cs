using System;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class AttachmentOfficerParam
	{
		public string PublishFlag { get; set; }
	}

    public class AttachFileOfficerForCA
    {
        public int INST_ATTACHMENT_OFFICER_ID { get; set; } //PK ID
        public int? INST_ID { get; set; }
        public string INST_ATTACHMENT_OFFICER_NAME { get; set; }
        public string INST_ATTACHMENT_OFFICER_PATH { get; set; }
        public string WF_INSTANCE_ID { get; set; }
        public string PUBLISH_FLAG { get; set; }
        public int? INST_ATTACHMENT_TYPE_ID { get; set; }
        public int? UPDATE_USER_ID { get; set; } //FIX -55 อัพเดทจาก CA
        public DateTime? UPDATE_DATE { get; set; }
    }
}

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class BpmProcFilterParam: OffsetFilterParam
	{
		public int? PersonalId { get; set; }
		public int? InstId { get; set; }
		public int? RefInstId { get; set; }
		public int? FlowId { get; set; }
		public string FlowCode { get; set; }
		public string StatusCode { get; set; }
		public string GroupStatusCode { get; set; }
		public string FormCode { get; set; }
		public int? CreateUserId { get; set; }
		public int? OfficerOrganizeId { get; set; }
		public bool? ExcludeSystemCreate { get; set; }
		public string ViewListReportText { get; set; }
		public string TrackingCode { get; set; }
		public string TrackingCodeLike { get; set; }

		public string Ext1 { get; set; }
		public string Ext2 { get; set; }
		public string Ext3 { get; set; }
		public string Ext4 { get; set; }
		public string Ext5 { get; set; }
	}

	public class BpmProcFilterParamControlPanel : OffsetFilterParam
	{
		public int? PersonalId { get; set; }
		public int? InstId { get; set; }
		public int? RefInstId { get; set; }
		public int? FlowId { get; set; }
		public string FlowCode { get; set; }
		public string StatusCode { get; set; }
		public string GroupStatusCode { get; set; }
		public string FormCode { get; set; }
		public int? CreateUserId { get; set; }
		public int? OfficerOrganizeId { get; set; }
		public bool? ExcludeSystemCreate { get; set; }
		public string ViewListReportText { get; set; }
		public string TrackingCode { get; set; }
		public string Date { get; set; }
	}
}

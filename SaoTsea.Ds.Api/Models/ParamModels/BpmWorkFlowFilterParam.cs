namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class BpmWorkFlowFilterParam
    {
        public string FlowCode { get; set; }
        public string StatusCode { get; set; }
        public string OrgLv { get; set; }
        public int? OfficerId { get; set; }
        public int? OrgId { get; set; }
        public int? Offset { get; set; }
        public int? Length { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
        public string Ext5 { get; set; }
        public string CposText { get; set; }
        public bool RequireTotalCount { get; set; }
        public string SortSelector { get; set; }
        public bool SortDesc { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}

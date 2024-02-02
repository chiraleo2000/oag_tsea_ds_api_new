using DevExpress.Xpo;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
    [NonPersistent]
    public class SearchOrganizeResult
    {
		public int ORGANIZE_ID { get; set; }
		public string ORGANIZE_ECMS_ID { get; set; }
		public string ORGANIZE_NAME_THA { get; set; }
		public string ORGANIZE_ABBR_THA { get; set; }
		public string ORGANIZE_NAME_DETAIL { get; set; }
		public int ORG_LEVEL_ID { get; set; }
		public int ORGANIZE_SEQ { get; set; }
		public string ORGANIZE_TELEPHONE { get; set; }
		public int ORGANIZE_ROOT_ID { get; set; }
		public int ORGANIZE_LEVEL_PARENT { get; set; }
	}
}

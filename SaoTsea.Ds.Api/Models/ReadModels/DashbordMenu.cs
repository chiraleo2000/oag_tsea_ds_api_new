namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class DashbordMenu
	{
		public int? MODULE_ID { get; set; }
		public string MODULE_SEQ { get; set; }
		public string MODULE_CODE { get; set; }
		public string MODULE_NAME { get; set; }
		public string MODULE_URL { get; set; }
		public string MODULE_ICON { get; set; }
		public string MODULE_REMARK { get; set; }
		public string MODULE_NEW_WINDOW_FLAG { get; set; }
		public int? MODULE_PARENT_ID { get; set; }
		public int? MODULE_LEVEL { get; set; }
		public string PERMISSION_CODE { get; set; }
	}
}

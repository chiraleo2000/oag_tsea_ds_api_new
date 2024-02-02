using Newtonsoft.Json;
using SaoTsea.Ds.Api.Core;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class Menu
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
		[JsonIgnore] public string PERMISSION_CODE { get; set; }
        public string SECTION_CODE_LIST { get; set; }
        public string ROLE_CODE_USE { get; set; }
		[ExcludeFromResultSet] public MenuPermission PERMISSION { get; set; }
	}

	public class MenuPermission
	{
		public bool ADD { get; set; }
		public bool EDIT { get; set; }
		public bool DELETE { get; set; }
		public bool VIEW { get; set; }
		public bool UPLOAD { get; set; }
		public bool DOWNLOAD { get; set; }
	}
}

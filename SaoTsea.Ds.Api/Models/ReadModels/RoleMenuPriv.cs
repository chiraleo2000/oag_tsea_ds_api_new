namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class RoleMenuPriv
	{
		public int MODULE_ID { get; set; }
		public string MODULE_ICON { get; set; }
		public string MODULE_NAME { get; set; }
		public int MODULE_PARENT_ID { get; set; }
        public int MODULE_LEVEL { get; set; }
		public string MODULE_SEQ { get; set; }
		public RoleMenuPrivPermission[] PERMISSION { get; set; }
	}

	public class RoleMenuPrivPermission
	{
		public int ROLE_PRIV_ID { get; set; }
		public int MODULE_PRIV_ID { get; set; }
		public int PERMISSION_ID { get; set; }
		public string PRIV_FLAG { get; set; }
		public string PERMISSION_NAME { get; set; }
	}

	public class RoleUser
	{
		public int USER_ROLE_ID { get; set; }
		public int USER_ID { get; set; }
		public string PERSONAL_FULL_NAME { get; set; }
		public string POSITION_NAME { get; set; }
		public string ORG_NAME { get; set; }
	}
}

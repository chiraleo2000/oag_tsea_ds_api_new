namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class RoleInfo
	{
		public string AppCode { get; set; }
		public int RoleId { get; set; }
		public string RoleCode { get; set; }
		public string RoleName { get; set; }

		/// <summary>
		/// รหัสอ้างอิงของ Role นี้ เช่น RoleCode เป็น ORGC RefId จะเป็น ID ของหน่วยงาน, RoleCode เป็น PER RefId จะเป็น ID ของผู้ใช้งาน
		/// </summary>
		public int OrgRefId { get; set; }

		public int OrgLevel { get; set; }
	}

    public class UserRoleEntity
    {
        public long NumberId { get; set; }
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public int OrgLv { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public string RecordStatus { get; set; }
        public string DelFlag { get; set; }
        public string RiRecordStatus { get; set; }
        public string RiDelFlag { get; set; }
        public int AppId { get; set; }
        public string AppCode { get; set; }
        public int RoleOrganizeId { get; set; }
        public int OrganizeId { get; set; }
        public int OrganizeRootId { get; set; }
        public string UserName { get; set; }
        public int PersonalId { get; set; }
        public string PersonalFullName { get; set; }
        public string PositionName { get; set; }
        public string OrgName { get; set; }
        public int UserType { get; set; }
        public string AdminCode { get; set; }
        public string PositionMngId { get; set; }
        public string AppName { get; set; }
        public string AppRemark { get; set; }
        public string AppIcon { get; set; }
        public string AppUrl { get; set; }
        public string AppSeq { get; set; }
    }
}

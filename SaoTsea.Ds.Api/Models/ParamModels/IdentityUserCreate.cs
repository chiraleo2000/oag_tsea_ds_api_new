namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class IdentityUserCreate
	{
		public string id { get; set; }
		public string userName { get; set; }
		public string email { get; set; }
		public bool isEnabled { get; set; } = true;
	}
}

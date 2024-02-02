namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class FilterParam
	{
		public bool RecordStatus { get; set; } = true;
		public bool DeleteFlag { get; set; } = true;
		public int? RoleId { get; set; }
		public int? AppId { get; set; } 
	}
}

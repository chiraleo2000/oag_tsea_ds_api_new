namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class WorkTimeCardFilter: FilterParam
	{
		public bool? SevenDayLater { get; set; }
		public int? PersonalId { get; set; }
	}
}

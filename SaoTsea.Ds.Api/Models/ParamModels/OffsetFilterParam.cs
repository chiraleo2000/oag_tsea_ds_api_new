namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class OffsetFilterParam: FilterParam
	{
        public int Offset { get; set; } = 0;
        public int Length { get; set; } = 10;
        public bool RequireTotalCount { get; set; } = true;
	}
}

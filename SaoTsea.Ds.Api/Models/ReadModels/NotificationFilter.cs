using SaoTsea.Ds.Api.Models.ParamModels;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class NotificationFilter: OffsetFilterParam
	{
		public int? PersonalId { get; set; }
		public bool? UnRead { get; set; }
	}
}

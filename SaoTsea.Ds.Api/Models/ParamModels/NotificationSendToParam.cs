using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class NotificationSendToParam: INeedXpoBinding
	{
		public BPM_NOTIFICATION Body { get; set; }
		public int[] SendToPersonal { get; set; }
	}
}

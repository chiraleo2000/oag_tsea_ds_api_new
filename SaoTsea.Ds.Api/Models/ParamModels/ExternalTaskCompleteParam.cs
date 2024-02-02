using System.Collections.Generic;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class ExternalTaskCompleteParam
	{
		public Dictionary<string, object> InputVariables { get; set; }
		public Dictionary<string, object> OutVariables{ get; set; }
	}
}

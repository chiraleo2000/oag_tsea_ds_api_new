using Newtonsoft.Json.Linq;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class TaskCompleteParam
	{
		public JObject Submission { get; set; }
		public string TaskId { get; set; }
		public int? BackendId { get; set; }
	}
}

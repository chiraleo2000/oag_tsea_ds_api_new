using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
	public class FormValidateResult
	{
		public string Message { get; set; }
		public bool IsStrict { get; set; }
		public bool Validity { get; set; }
	}
}

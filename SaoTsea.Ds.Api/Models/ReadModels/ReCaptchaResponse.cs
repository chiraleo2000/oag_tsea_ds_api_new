using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
	public class ReCaptchaResponse
	{
		public bool Success { get; set; }
		public float Score { get; set; }
		public string Action { get; set; }
		[JsonProperty("challenge_ts")]
		public DateTime ChallengeTs { get; set; }
		public string Hostname { get; set; }
	}
}

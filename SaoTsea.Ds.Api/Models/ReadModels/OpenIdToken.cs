using Newtonsoft.Json;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class OpenIdToken
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }
		[JsonProperty("refresh_expires_in")]
		public int RefreshExpiresIn { get; set; }
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }
	}
}

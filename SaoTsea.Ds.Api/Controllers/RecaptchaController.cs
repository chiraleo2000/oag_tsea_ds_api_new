using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecaptchaController : ControllerBase
	{
		private readonly AppSetting _setting;
		private readonly IHttpClientFactory _httpClientFactory;
		public RecaptchaController(AppSetting setting,  IHttpClientFactory httpClientFactory)
		{
			_setting = setting;
			_httpClientFactory = httpClientFactory;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<StatusResult<ReCaptchaResponse>> CheckToken([FromQuery] string recaptchaToken)
		{
			HttpClient client = _httpClientFactory.CreateClient();
			var respone =
				await client.GetAsync(
					$"https://www.google.com/recaptcha/api/siteverify?secret={_setting.Keys.ReCaptcha}&response={recaptchaToken}");
			
			if (respone.StatusCode != HttpStatusCode.OK)
			{
				return StatusResult.Error("ไม่สำเร็จรหัส: " + respone.StatusCode);
			}

			string content = await respone.Content.ReadAsStringAsync();
			ReCaptchaResponse result = JsonConvert.DeserializeObject<ReCaptchaResponse>(content);

			return StatusResult.Ok(result);
		}
	}
}

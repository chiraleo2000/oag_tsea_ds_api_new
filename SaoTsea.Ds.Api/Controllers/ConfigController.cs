using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConfigController : ControllerBase
	{
		private AppSetting _setting;
		public ConfigController(AppSetting setting)
		{
			_setting = setting;
		}

	}
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CmsHolidayInfoController : BetimesControllerBase
	{
		[XpoFilter]
		[HttpGet]
		public async Task<VIEW_HOLIDAY_INFO[]> Gets()
		{
			return await DB.GetObjectListAsync<VIEW_HOLIDAY_INFO>();
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_HOLIDAY_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_HOLIDAY_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

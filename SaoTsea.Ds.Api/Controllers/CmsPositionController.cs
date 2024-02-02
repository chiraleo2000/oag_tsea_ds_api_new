using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmsPositionController : BetimesControllerBase
    {
		[XpoFilter]
		[HttpGet]
		[AllowAnonymous]
		public async Task<CMS_POSITION[]> Gets()
		{
			return await DB.GetObjectListAsync<CMS_POSITION>();
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_POSITION value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_POSITION value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

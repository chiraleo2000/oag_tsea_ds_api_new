using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmSystemInfoController : BetimesControllerBase
    {
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_SYSTEM_INFO[]> Gets()
		{
			return await DB.GetObjectListAsync<ADM_SYSTEM_INFO>();
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(ADM_SYSTEM_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_SYSTEM_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

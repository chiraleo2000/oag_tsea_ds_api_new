using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmSSOController : BetimesControllerBase
    {
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_SSO[]> Gets()
		{
			return await DB.GetObjectListAsync<ADM_SSO>();
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(ADM_SSO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_SSO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

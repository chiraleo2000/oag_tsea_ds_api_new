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
	public class AdmModulePrivController : BetimesControllerBase
	{
		[LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_MODULE_PRIV[]> Gets()
		{
			return await DB.GetObjectListAsync<ADM_MODULE_PRIV>();
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(ADM_MODULE_PRIV value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[AllowAnonymous]
		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_MODULE_PRIV value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[HttpDelete("{id}")]
		public async Task<StatusResult> Delete(int id)
		{
			await DB.DirectDeleteAsync<ADM_MODULE_PRIV>(id);
			return StatusResult.Ok();
		}
	}
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdmRolePrivController : BetimesControllerBase
	{
		[LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_ROLE_PRIV[]> Gets()
		{
			return await DB.GetObjectListAsync<ADM_ROLE_PRIV>();
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(ADM_ROLE_PRIV value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_ROLE_PRIV value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("batch")]
		public async Task<StatusResult> UpdateBatch(ADM_ROLE_PRIV[] value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

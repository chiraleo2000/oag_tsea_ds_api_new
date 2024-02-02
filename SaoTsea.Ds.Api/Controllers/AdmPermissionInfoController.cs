using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdmPermissionInfoController : BetimesControllerBase
	{
		[LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_PERMISSION_INFO[]> Gets()
		{
			return await DB.GetObjectListAsync<ADM_PERMISSION_INFO>();
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(ADM_PERMISSION_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_PERMISSION_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

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
	public class CmsGroupStatusController : BetimesControllerBase
	{

		[AllowAnonymous]
		[XpoFilter]
		[HttpGet]
		public async Task<CMS_GROUP_STATUS[]> Gets()
		{
			return await DB.GetObjectListAsync<CMS_GROUP_STATUS>();
		}

		[HttpPost]
		[XpoAutoUpdate]
		public async Task<StatusResult> Post(CMS_GROUP_STATUS value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_GROUP_STATUS value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

using System.Linq;
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
    public class CmsTitleController : BetimesControllerBase
    {
		[HttpGet]
		[XpoFilter]
		[AllowAnonymous]
		public async Task<CMS_TITLE[]> Get()
		{
			return (await DB.GetObjectListAsync<CMS_TITLE>()).OrderBy(_ => _.TITLE_ID).ToArray();
		}

		[HttpGet("{id}")]
		public async Task<StatusResult<CMS_TITLE>> GetById(int id)
		{
			var title = await DB.GetObjectByKeyAsync<CMS_TITLE>(id);
			if (title == null)
			{
				return StatusResult.Error("ไม่พบข้อมูล");
			}

			return StatusResult.Ok(title);
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_TITLE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_TITLE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

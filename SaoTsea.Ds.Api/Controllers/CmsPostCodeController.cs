using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmsPostCodeController : BetimesControllerBase
    {
		[HttpGet]
		[XpoFilter]
		[AllowAnonymous]
		public async Task<VIEW_POSTCODE[]> Get()
		{
			return await DB.GetObjectListAsync<VIEW_POSTCODE>();
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_SUB_POSTCODE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_SUB_POSTCODE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoFilter]
		[HttpPost("search")]
		public async Task<PagingResult<SearchPostCode>> Search(SearchParam param)
		{
			return await DB.StoredProcedure.SearchPostCode(
				DB.ConditionContext.ToSql(param.Condition),
				param.Offset ?? 0,
				param.Length ?? 100);
		}
	}
}

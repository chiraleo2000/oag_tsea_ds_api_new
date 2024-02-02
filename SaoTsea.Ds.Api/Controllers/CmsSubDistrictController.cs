using System;
using System.Globalization;
using System.Linq;
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
    public class CmsSubDistrictController : BetimesControllerBase
    {
		[HttpGet]
		[XpoFilter]
		[AllowAnonymous]
		public async Task<CMS_SUB_DISTRICT[]> Get()
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("th-Th");
			bool ignoreCase = true;
			StringComparer comp = StringComparer.Create(ci, ignoreCase);
			return (await DB.GetObjectListAsync<CMS_SUB_DISTRICT>())
				   .OrderBy(_ => _.SUB_DISTRICT_NAME_THA, comp).ToArray();
		}

		[HttpGet("{id}/post-code")]
		[XpoFilter]
		[AllowAnonymous]
		public Task<VIEW_POSTCODE[]> GetsPostCode(int id)
		{
			return DB.GetObjectListAsync<VIEW_POSTCODE>($"SUB_DISTRICT_ID={id}");
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_SUB_DISTRICT value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_SUB_DISTRICT value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoFilter]
		[HttpPost("search")]
		public async Task<PagingResult<SearchSubDistrict>> Search(SearchParam param)
		{
			return await DB.StoredProcedure.SearchSubDistrict(
				DB.ConditionContext.ToSql(param.Condition),
				param.Offset ?? 0,
				param.Length ?? 100);
		}
	}
}

using System;
using System.Globalization;
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
    public class CmsDistrictController : BetimesControllerBase
	{
		[HttpGet]
		[XpoFilter]
		[AllowAnonymous]
		public async Task<CMS_DISTRICT[]> Get()
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("th-Th");
			bool ignoreCase = true;
			StringComparer comp = StringComparer.Create(ci, ignoreCase);
			return (await DB.GetObjectListAsync<CMS_DISTRICT>())
				   .OrderBy(_ => _.DISTRICT_NAME_THA, comp).ToArray();
		}

		[HttpGet("{districtId}/sub-district")]
		[AllowAnonymous]
		public async Task<CMS_SUB_DISTRICT[]> GetByDistrictId(int districtId)
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("th-Th");
			bool ignoreCase = true;
			StringComparer comp = StringComparer.Create(ci, ignoreCase);
			var result = await DB.GetObjectListAsync<CMS_SUB_DISTRICT>("DISTRICT_ID=" + districtId);
			return result?.OrderBy(_ => _.SUB_DISTRICT_NAME_THA, comp).ToArray();
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_DISTRICT value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_DISTRICT value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

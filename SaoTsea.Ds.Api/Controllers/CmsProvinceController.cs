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
    public class CmsProvinceController : BetimesControllerBase
    {
		[HttpGet]
		[XpoFilter]
		[AllowAnonymous]
		public async Task<CMS_PROVINCE[]> Get()
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("th-Th");
			bool ignoreCase = true;
			StringComparer comp = StringComparer.Create(ci, ignoreCase);

            var r = await DB.GetObjectListAsync<CMS_PROVINCE>();

			return r.OrderBy(_ => _.PROVINCE_NAME_THA, comp).ToArray();
		}

		[AllowAnonymous]
		[HttpGet("{provinceId}")]
		public async Task<CMS_PROVINCE[]> GetByPersonalId(int provinceId)
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("th-Th");
			bool ignoreCase = true;
			StringComparer comp = StringComparer.Create(ci, ignoreCase);
			return (await DB.GetObjectListAsync<CMS_PROVINCE>("PROVINCE_ID=" + provinceId))
				.OrderBy(_ => _.PROVINCE_NAME_THA, comp).ToArray();
		}


		[HttpGet("{provinceId}/district")]
		[AllowAnonymous]
		public async Task<CMS_DISTRICT[]> GetByProvinceId(int provinceId)
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("th-Th");
			bool ignoreCase = true;
			StringComparer comp = StringComparer.Create(ci, ignoreCase);
			return (await DB.GetObjectListAsync<CMS_DISTRICT>("PROVINCE_ID=" + provinceId))
				   .OrderBy(_ => _.DISTRICT_NAME_THA, comp).ToArray();
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_PROVINCE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_PROVINCE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

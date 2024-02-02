using System.Collections.Generic;
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
	public class CmsOrganizeProvinceController : BetimesControllerBase
	{
		[XpoFilter]
		[HttpGet]
		[AllowAnonymous]
		public Task<VIEW_ORGANIZE_PROVINCE[]> Gets()
		{
			return DB.GetObjectListAsync<VIEW_ORGANIZE_PROVINCE>();
		}

		[AllowAnonymous]
		[XpoFilter]
		[HttpGet("province/{provinceId}/users")]
		public async Task<IEnumerable<OrganizeProvinceUser>> Gets(int provinceId)
		{
			var op = await DB.GetObjectListAsync<CMS_ORGANIZE_PROVINCE>(
				$"PROVINCE_ID={provinceId}");

			if (op == null)
			{
				return null;
			}

			string organizeComma = op.Select(p => p.ORGANIZE_ID.ToString())
			                         .Aggregate((_old, _new) => $"{_new},{_old}");

			var personal = await DB.GetObjectListAsync<VIEW_PERSONAL>(
				$"ORG_ID IN ({organizeComma})");


			return personal?.Select(p => new OrganizeProvinceUser()
			{
				PersonalId = p.PERSONAL_ID,
				Username = "1"
			});
		}



		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_ORGANIZE_PROVINCE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_ORGANIZE_PROVINCE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;
using SaoTsea.Ds.Api.Utility;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CmsStatusController : BetimesControllerBase
	{
		[AllowAnonymous]
		[XpoFilter]
		[HttpGet]
		public async Task<VIEW_STATUS[]> Gets([FromQuery] StatusFilterParam param)
		{
			string condition = "";
			if (!string.IsNullOrEmpty(param.GroupStatusCode))
			{
				condition = WhereUtility.And(condition, $"GROUP_STATUS_CODE='{param.GroupStatusCode}'");
			}
			if (!string.IsNullOrEmpty(param.StatusCode))
			{
				condition = WhereUtility.And(condition, $"STATUS_CODE='{param.StatusCode}'");
			}

			return await DB.GetObjectListAsync<VIEW_STATUS>(condition);
		}

		[AllowAnonymous]
		[XpoFilter]
		[HttpGet("all")]
		public async Task<VIEW_STATUS[]> GetsStatus()
		{
			return await DB.GetXpQuery<VIEW_STATUS>()
				.OrderBy(_ => _.GROUP_STATUS_NAME)
				.ThenBy(_ => _.STATUS_NAME)
				.ToArrayAsync();
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(CMS_STATUS value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, CMS_STATUS value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

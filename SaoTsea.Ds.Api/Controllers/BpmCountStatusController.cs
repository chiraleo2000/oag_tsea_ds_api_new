using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Utility;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpmCountStatusController : BetimesControllerBase
	{
		[XpoFilter]
		[HttpGet]
		public async Task<VIEW_COUNT_STATUS_PROC_INST[]> Gets([FromQuery] BpmCountStatusParam param)
		{
			string condition = "";
			if (param.PersonalId.HasValue)
			{
				condition = WhereUtility.And(condition, $"PERSONAL_ID={param.PersonalId}");
			}
			if (param.StatusCode != null)
			{
				condition = WhereUtility.And(condition, $"STATUS_CODE='{param.StatusCode}'");
			}

			return await DB.GetObjectListAsync<VIEW_COUNT_STATUS_PROC_INST>(condition);
		}

		[AllowAnonymous]
		[XpoFilter]
		[HttpGet("count-group-status")]
		public async Task<VIEW_COUNT_GROUP_STATUS_PROC_INST[]> CountGroupStatus()
		{
			return await DB.GetXpQuery<VIEW_COUNT_GROUP_STATUS_PROC_INST>().Where(_ => _.PERSONAL_ID == UserInfo.PersonalId).ToArrayAsync();
		}
	}
}

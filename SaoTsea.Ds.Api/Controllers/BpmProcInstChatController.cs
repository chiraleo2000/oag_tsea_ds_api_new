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
	public class BpmProcInstChatController : BetimesControllerBase
	{
		[AllowAnonymous]
		[XpoFilter]
		[HttpGet]
		public Task<VIEW_PROC_INST_CHAT[]> Gets([FromQuery] BpmChatFilterParam param)
		{
			IQueryable<VIEW_PROC_INST_CHAT> query = DB.GetXpQuery<VIEW_PROC_INST_CHAT>();
			if (param.BpmInstanceId.HasValue)
			{
				query = query.Where(_ => _.INST_ID == param.BpmInstanceId);
			}

			return query.OrderBy(_ => _.CREATE_DATE).ToArrayAsync();
		}

		[HttpGet("count")]
		public async Task<int> GetCount([FromQuery] BpmChatFilterParam param)
		{
			int c = await DB.GetXpQuery<BPM_PROC_INST_CHAT>()
			                .CountAsync(p => p.INST_ID == param.BpmInstanceId);
			return c;
		}

		[HttpPost]
		[XpoAutoUpdate]
		public async Task<StatusResult> Post(BPM_PROC_INST_CHAT value)
		{
			value.SENDER_ID = UserInfo.PersonalId;
			await DB.CommitChangesAsync();

			return StatusResult.Ok();
		}
		[HttpPost("search")]
		public async Task<VIEW_PROC_INST_CHAT[]> searchChat([FromBody] BpmChatParam param)
		{

			string condition = "";
			condition = WhereUtility.And(condition, $"INST_ID={param.BPM_INSTANCE_ID}");
			if (param.BPM_SEARCH_TEXT != null && param.BPM_SEARCH_TEXT != "")
			{
				//condition = WhereUtility.And(condition, $"INST_CHAT_MASSAGE like '{param.BPM_SEARCH_TEXT}'");
				condition = WhereUtility.And(condition, $"INST_CHAT_MASSAGE LIKE '%{param.BPM_SEARCH_TEXT}%'");
			}

			return await DB.GetObjectListAsync<VIEW_PROC_INST_CHAT>(condition);
		}
	}
}

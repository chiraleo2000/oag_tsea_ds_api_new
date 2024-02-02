using System.Collections.Generic;
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
	public class BpmProcInstCaseRelationController : BetimesControllerBase
	{
		[XpoFilter]
		[HttpGet]
		[AllowAnonymous]
		public async Task<VIEW_CASE_RELATION[]> Gets([FromQuery] CaseRelationFilterParam filter)
		{
			IQueryable<VIEW_CASE_RELATION> query = DB.GetXpQuery<VIEW_CASE_RELATION>();
			if (filter.PersonalId.HasValue)
			{
				query = query.Where(_ => _.PERSONAL_ID == filter.PersonalId);
			}
			if (filter.RefInstId.HasValue)
			{
				query = query.Where(_ => _.REF_INST_ID == filter.RefInstId);
			}

			return await query.OrderByDescending(_ => _.CREATE_DATE).ToArrayAsync();
		}


		[AllowAnonymous]
		[HttpPost("create-set")]
		[XpoAutoUpdate]
		public async Task<StatusResult> CreateFromList(BPM_PROC_INST_CASE_RELATION[] value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}


		[AllowAnonymous]
		[XpoFilter]
		[HttpGet("{refInstId}/RefInstId")]
		public async Task<VIEW_CASE_RELATION_APPOINTMENT[]> GetByRefInstId(int? refInstId)
		{
			string condition = "";
			if (refInstId != null)
			{
				condition = WhereUtility.And(condition, $"REF_INST_ID={refInstId}");
			}

			return await DB.GetObjectListAsync<VIEW_CASE_RELATION_APPOINTMENT>(condition);
		}

		[HttpGet("{instId}/proc-inst/distinct")]
		public async Task<List<ProcInstRelationResult>> GetInstDistinct(int instId)
		{
			return await DB.StoredProcedure.GetProcInstDistinctRelation(instId);
		}

		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(BPM_PROC_INST_CASE_RELATION value)
		{
			var cases = await DB.GetObjectAsync<BPM_PROC_INST_CASE_RELATION>(
				$"INST_ID='{value.INST_ID}' AND REF_INST_ID= '{value.REF_INST_ID}'");
			if (cases != null)
			{
				return StatusResult.Error("เคสที่เกี่ยวข้องนี้มีอยู่แล้ว");
			}
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, BPM_PROC_INST_CASE_RELATION value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

using System.Linq;
using System.Threading.Tasks;
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
    public class BpmProcInstAttachmentTypeController : BetimesControllerBase
    {
		[XpoFilter]
		[HttpGet]
		[AllowAnonymous]
		public async Task<BPM_PROC_INST_ATTACHMENT_TYPE[]> Gets([FromQuery] AttachmentTypeFilterParam filter)
		{
			string condition = "";
			if (!string.IsNullOrEmpty(filter.OfficerAttachmentFlag))
			{
				condition = WhereUtility.And(condition, $"OFFICER_ATTACHMENT_FLAG='{filter.OfficerAttachmentFlag}'");
			}

			return await DB.GetObjectListAsync<BPM_PROC_INST_ATTACHMENT_TYPE>(condition);
		}

		[XpoFilter]
		[HttpGet("code/{attCode}")]
		[AllowAnonymous]
		public async Task<BPM_PROC_INST_ATTACHMENT_TYPE> GetByCode(string attCode)
		{
			return await DB.GetObjectAsync<BPM_PROC_INST_ATTACHMENT_TYPE>($"INST_ATTACHMENT_TYPE_CODE='{attCode}'");
		}

		[XpoFilter]
		[HttpGet("form-code/{attCode}")]
		[AllowAnonymous]
		public async Task<VIEW_ATTACHMENT_TYPE_FORM[]> GetByFormCode(string attCode)
		{
			string condition = "";
			if (!string.IsNullOrEmpty(attCode))
			{
				condition = WhereUtility.And(condition, $"FORM_CODE='{attCode}'");
			}

			VIEW_ATTACHMENT_TYPE_FORM[] typeForm = await DB.GetObjectListAsync<VIEW_ATTACHMENT_TYPE_FORM>(condition);
			return typeForm?.OrderBy(_ => _.ATTACHMENT_TYPE_SEQ).ToArray();
		}

		// บาสเพิ่มใหม่
		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post(BPM_PROC_INST_ATTACHMENT_TYPE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, BPM_PROC_INST_ATTACHMENT_TYPE value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoFilter]
		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<BPM_PROC_INST_ATTACHMENT_TYPE> GetById(string id)
		{
			return await DB.GetObjectAsync<BPM_PROC_INST_ATTACHMENT_TYPE>($"INST_ATTACHMENT_TYPE_ID='{id}'");
		}

		[XpoFilter]
		[HttpGet("form/{id}")]
		[AllowAnonymous]
		public async Task<VIEW_DOC_ATTACHMENT_ALL[]> GetByFormId(string id)
		{
			return await DB.GetObjectListAsync<VIEW_DOC_ATTACHMENT_ALL>($"FORM_ID='{id}'");
		}

	}
}

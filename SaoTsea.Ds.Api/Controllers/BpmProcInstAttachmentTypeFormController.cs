using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpmProcInstAttachmentTypeFormController : BetimesControllerBase
    {
		
		[XpoFilter]
		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<BPM_PROC_INST_ATTACHMENT_TYPE_FORM> GetById(string id)
		{
			return await DB.GetObjectAsync<BPM_PROC_INST_ATTACHMENT_TYPE_FORM>($"ATTACHMENT_TYPE_ID='{id}'");
		}

	}
}

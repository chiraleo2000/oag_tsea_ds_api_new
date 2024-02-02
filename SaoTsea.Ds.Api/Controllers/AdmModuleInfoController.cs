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
	public class AdmModuleInfoController : BetimesControllerBase
	{
		[LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<VIEW_MODULE_INFO[]> Gets()
		{
			VIEW_MODULE_INFO[] moduleInfo = null;
			moduleInfo = await DB.GetObjectListAsync<VIEW_MODULE_INFO>();
			return moduleInfo?.OrderBy(_ => _.MODULE_SEQ.Length).ThenBy(_ => _.MODULE_SEQ).ToArray();
		}

		[HttpGet("{moduleId}/permissions")]
		public async Task<VIEW_MODULE_PRIV[]> GetPermissions(int moduleId)
		{
			return await DB.GetObjectListAsync<VIEW_MODULE_PRIV>("MODULE_ID=" + moduleId);
		}

		[HttpGet("{appId}/seqlastid")]
		public async Task<ModuleCodeSeqLast> GetModuleCodeSeqLast(int appId)
		{
			return await DB.StoredProcedure.GetModuleCodeSeqLast(appId);
		}

		[XpoAutoUpdate]
		[HttpPost]
		[AllowAnonymous]
		public async Task<StatusResult> Post(ADM_MODULE_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, ADM_MODULE_INFO value)
		{
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[HttpDelete("{id}")]
		public async Task<StatusResult> Delete(int id)
		{
			ADM_MODULE_INFO moduleInfo = await DB.GetObjectByKeyAsync<ADM_MODULE_INFO>(id);
			moduleInfo.DEL_FLAG = "Y";
			DB.UpdateObject(moduleInfo);
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

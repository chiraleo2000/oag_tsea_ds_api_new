using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class AdmAppOrgController : BetimesControllerBase
    {
		[LoadRole]
	    [XpoFilter]
	    [HttpGet]
	    public async Task<VIEW_APP_ORG[]> Gets([FromServices] ConditionContext c)
	    {
		    c.AppId = 0;
		    return await DB.GetObjectListAsync<VIEW_APP_ORG>();
	    }

	    [XpoAutoUpdate]
	    [HttpPost]
	    public async Task<StatusResult> Post(ADM_APP_ORG value)
	    {

		    ADM_APP_ORG app = await DB
			    .GetObjectAsync<ADM_APP_ORG>($"APP_ID={value.APP_ID} AND " +
			                                 $"ORG_ROOT_ID={value.ORG_ROOT_ID}");

		    if (app != null)
		    {
			    return StatusResult.Error("App นี้ถูกเพิ่มไปแล้ว");
		    }

		    await DB.CommitChangesAsync();
		    return StatusResult.Ok();
	    }

		[XpoAutoUpdate]
	    [HttpPut("{id}")]
	    public async Task<StatusResult> Put(int id, ADM_APP_ORG value)
	    {
		    ADM_APP_ORG appOrg = await DB.GetObjectByKeyAsync<ADM_APP_ORG>(id);
		    if (appOrg.APP_ID != value.APP_ID)
		    {
			    int capp = await DB.GetXpQuery<ADM_APP_ORG>()
				    .Where(_ => _.APP_ID == value.APP_ID 
				                && _.ORG_ROOT_ID == value.ORG_ROOT_ID
				                && _.RECORD_STATUS == "A"
				                && _.DEL_FLAG == "N")
				    .CountAsync();

			    if (capp >= 1)
			    {
				    return StatusResult.Error("App นี้ถูกเพิ่มไปแล้ว");
			    }
		    }

		    DB.UpdateObject(value);
		    await DB.CommitChangesAsync();
		    return StatusResult.Ok();
	    }

	    [HttpDelete("{id}")]
	    public async Task<StatusResult> Delete(int id)
	    {
		    ADM_APP_ORG appOrg = await DB.GetObjectByKeyAsync<ADM_APP_ORG>(id);
		    appOrg.DEL_FLAG = "Y";
		    DB.UpdateObject(appOrg);
		    await DB.CommitChangesAsync();
		    return StatusResult.Ok();
	    }
    }
}

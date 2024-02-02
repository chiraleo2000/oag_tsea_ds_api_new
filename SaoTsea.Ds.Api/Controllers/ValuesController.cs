using Microsoft.AspNetCore.Mvc;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
		//NOTE : สำหรับ Check รายละเอียด api 
		[HttpGet]
		public ActionResult<string> Get()
		{
			return Ok("Kypopza say empty");
		}

	


		//[HttpGet]
		//public async Task<ActionResult> getMenus()
		//{
		//	List<Menu> internalMenu = await DB.StoredProcedure.GetsMenu(roleId, appCode);
		//}
	}
}

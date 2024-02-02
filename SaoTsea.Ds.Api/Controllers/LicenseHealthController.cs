using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LicenseHealthController : BetimesControllerBase
	{
		[XpoFilter]
		[HttpPost]
		[AllowAnonymous]
		public async Task<StatusResult<LicenseHealthResult>> Gets(LicenseHealthParam param)
		{
			LicenseHealthResult result = new LicenseHealthResult();
			if (string.IsNullOrEmpty(param.license_code))
			{
				return StatusResult.Error("ไม่พบ Param เลขอนุญาต License Code");
			}

			var attach = await DB.GetXpQuery<VIEW_PROC_INST_ATTACHMENT_OFFICER>()
										  .Where(_ => _.TRACKING_CODE == param.license_code)
										  .ToArrayAsync();
			if (attach.Length < 1)
			{
				return StatusResult.Error("ไม่พบใบคำขอเลขใบอนุญาตนี้ " + param.license_code);
			}

			var attach2 = await DB.GetXpQuery<VIEW_PROC_INST_ATTACHMENT_OFFICER>()
										  .Where(_ => _.TRACKING_CODE == param.license_code && _.PUBLISH_FLAG == 'Y' &&
										  _.STATUS_CODE.Trim() == "CP")
										  .ToArrayAsync();
			if (attach2.Length > 0)
			{
				result.name = attach2[0].INST_ATTACHMENT_OFFICER_NAME;
				result.url = attach2[0].INST_ATTACHMENT_OFFICER_PATH;
			}
			else
			{
				return StatusResult.Error("เลขคำขอใบอนุญาตนี้อยู่ในขั้นตอนกำลังดำเนินการ " + param.license_code);
			}

			return StatusResult.Ok(result);
		}
	}
}

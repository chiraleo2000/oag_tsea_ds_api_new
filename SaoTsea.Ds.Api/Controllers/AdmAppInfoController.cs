using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdmAppInfoController : BetimesControllerBase
	{
		private ResourceUtility _resourceUtility;

		public AdmAppInfoController(ResourceUtility resourceUtility)
		{
			_resourceUtility = resourceUtility;
		}

        [LoadRole]
		[XpoFilter]
		[HttpGet]
		public async Task<ADM_APP_INFO[]> Gets([FromQuery] AppInfoFilterParam filterParam)
		{
			IQueryable<ADM_APP_INFO> query = DB.GetXpQuery<ADM_APP_INFO>();

			if (!string.IsNullOrEmpty(filterParam.InvisibleFlag))
			{
				query = query.Where(_ => _.APP_INVISIBLE_FLAG == filterParam.InvisibleFlag);
			}

			if (!string.IsNullOrEmpty(filterParam.ExternalFlag))
			{
				query = query.Where(_ => _.APP_EXTERNAL_FLAG == filterParam.ExternalFlag);
			}

			return await query.ToArrayAsync();
		}


		[XpoAutoUpdate]
		[HttpPost]
		public async Task<StatusResult> Post([FromForm] ADM_APP_INFO value)
		{
			if (value.UPLOAD_IMAGE != null)
			{
				ImageResource info = new ImageResource
				{
					File = value.UPLOAD_IMAGE,
					Destination = Path.Combine("img", "app"),
					Type = MagickFormat.Png,
					Extension = "png",
					Name = value.APP_CODE
				};

				await _resourceUtility.SaveImageToResource(info);
				value.APP_ICON = info.FullPath;
			}

			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[XpoAutoUpdate]
		[HttpPut("{id}")]
		public async Task<StatusResult> Put(int id, [FromForm] ADM_APP_INFO value)
		{
			if (value.UPLOAD_IMAGE != null)
			{
				ImageResource info = new ImageResource
				{
					File = value.UPLOAD_IMAGE,
					Destination = Path.Combine("img", "app"),
					Type = MagickFormat.Png,
					Extension = "png",
					Name = value.APP_CODE
				};

				await _resourceUtility.SaveImageToResource(info);
				value.APP_ICON = info.FullPath;
			}

			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}

		[HttpDelete("{id}")]
		public async Task<StatusResult> Delete(int id)
		{
			ADM_APP_INFO app = await DB.GetObjectByKeyAsync<ADM_APP_INFO>(id);
			app.DEL_FLAG = "Y";
			DB.UpdateObject(app);
			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}

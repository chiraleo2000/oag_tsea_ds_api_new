using Microsoft.AspNetCore.Http;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class PromoteIal1_3Param
	{
		public CMS_PERSONAL PERSONAL { get; set; }
		public IFormFile FRONT_PPD_PICTURE { get; set; }
		public IFormFile BACK_PPD_PICTURE { get; set; }
	}
}

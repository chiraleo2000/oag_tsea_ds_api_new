using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileController : ControllerBase
	{
		[HttpPost]
		public IActionResult Tets(IFormFile file)
		{

			return Ok(new
			{
				url = "www.google.com",
				name = "001x.jpg",
				size = 1000
			});
		}
	}
}

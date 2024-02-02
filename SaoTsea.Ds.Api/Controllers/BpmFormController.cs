using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BpmFormController: ControllerBase
	{
		private readonly DBHandlerCore _db;

		public BpmFormController(DBHandlerCore db)
		{
			_db = db;
		}

		[HttpGet]
		public Task<BPM_FORM[]> Gets()
		{
			return _db.GetObjectListAsync<BPM_FORM>();
		}
	}
}

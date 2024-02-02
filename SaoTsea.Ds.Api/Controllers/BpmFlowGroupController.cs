using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpmFlowGroupController : BetimesControllerBase
    {
        [XpoFilter]
        [HttpGet]
        public Task<BPM_FLOW_GROUP[]> Gets()
        {
            return DB.GetObjectListAsync<BPM_FLOW_GROUP>();
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpmProcInstAppointmentTypeController : BetimesControllerBase
    {
        [XpoFilter]
        [AllowAnonymous]
        [HttpGet]
        public async Task<BPM_PROC_INST_APPOINTMENT_TYPE[]> Gets()
        {
            return await DB.GetObjectListAsync<BPM_PROC_INST_APPOINTMENT_TYPE>();
        }
    }
}

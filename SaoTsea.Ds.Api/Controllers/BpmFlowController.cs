using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpmFlowController : BetimesControllerBase
    {
        [XpoFilter]
        [HttpGet]
        public Task<VIEW_PROC_FLOW[]> Gets()
        {
            return DB.GetObjectListAsync<VIEW_PROC_FLOW>();
        }

        [AllowAnonymous]
        [HttpGet("{groupId}/group")]
        public async Task<GroupFlow[]> GetByGroupId(int groupId)
        {
            var result = await DB.GetXpQuery<VIEW_PROC_FLOW>()
                .Where(_ => _.FLOW_GROUP_ID == groupId)
                .GroupBy(_ => _.FLOW_NAME)
                .Select(_ => new GroupFlow()
                {
                    FLOW_GROUP_ID = _.First().FLOW_GROUP_ID,
                    FLOW_NAME = _.First().FLOW_NAME,
                    FLOW_GROUP_NAME = _.First().FLOW_GROUP_NAME,
                    FLOW_CODE = _.First().FLOW_CODE
                })
                .ToArrayAsync();
            return result;
        }
    }
}

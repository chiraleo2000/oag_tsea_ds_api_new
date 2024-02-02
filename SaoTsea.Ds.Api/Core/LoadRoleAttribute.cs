using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
    public class LoadRoleAttribute: ActionFilterAttribute
    {
        public new int Order => 1;
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            UserPayload userInfo = context.HttpContext.RequestServices.GetService<UserPayload>();
            DBHandlerCore db = context.HttpContext.RequestServices.GetService<DBHandlerCore>();
            ///TODO : get role from UserId
            var userRole = await db.StoredProcedure.GetRoleUser(userInfo.UserId, "DS");


            if (userRole == null)
            {
                throw new Exception("ไม่พบบทบาทของคุณในระบบ");
            }

            userInfo.Roles = userRole.GroupBy(_ => _.AppCode).Select(_ => new RoleInfo
            {
                RoleId = _.First().RoleId,
                RoleCode = _.First().RoleCode,
                RoleName = _.First().RoleName,
                OrgRefId = _.First().RoleOrganizeId,
                OrgLevel = _.First().OrgLv
            });

            await next();
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
	public class XpoFilterAttribute : ActionFilterAttribute
	{
        public new int Order => 2;
        public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (
			    context.Filters.FirstOrDefault(_ => _.GetType() == typeof(AllowAnonymousFilter)) != null)
			{
				return;
			}

			UserPayload userInfo = context.HttpContext.RequestServices.GetService<UserPayload>();
			if (context.HttpContext.Request.Query.Any())
			{
				FilterParam filter =
					context.ActionArguments.Values
						.Where(_ =>
						{
							Type s = _.GetType();
							Type d = typeof(FilterParam);
							return s == d || s.IsSubclassOf(d);
						})
						.Cast<FilterParam>()
						.FirstOrDefault();

				if (filter == null)
				{
					filter = CreateFilterFromQuery(context.HttpContext.Request.Query);
					if (filter == null)
					{
						return;
					}
				}

				var conditionContext = context.HttpContext
					.RequestServices.GetService<ConditionContext>();

				if (!filter.RecordStatus)
				{
					conditionContext.RecordStatus = false;
				}

				if (!filter.DeleteFlag)
				{
					conditionContext.DeleteFlag = false;
				}

				if (filter.RoleId.HasValue)
				{
					var role = userInfo.Roles.SingleOrDefault(_ => _.RoleId == filter.RoleId);
					if (role == null || role.RoleCode != "ROOT")
					{
						conditionContext.SelfRootId = userInfo.OrganizeRootId;
					}
				}

				if (filter.AppId.HasValue)
				{
					conditionContext.AppId = (int)filter.AppId;
				}
			}
		}

		FilterParam CreateFilterFromQuery(IQueryCollection collection)
		{
			FilterParam filter = new FilterParam();
			if (collection.TryGetValue("RecordStatus", out StringValues value))
			{
				filter.RecordStatus = bool.Parse(value);
			}

			if (collection.TryGetValue("DeleteFlag", out value))
			{
				filter.DeleteFlag = bool.Parse(value);
			}

			if (collection.TryGetValue("RoleId", out value))
			{
				filter.RoleId = int.Parse(value);
			}

			if (collection.TryGetValue("AppId", out value))
			{
				filter.AppId = int.Parse(value);
			}

			return filter;
		}
	}
}
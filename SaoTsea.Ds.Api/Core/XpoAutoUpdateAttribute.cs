using System;
using System.Linq;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SaoTsea.Ds.Api.Core.DataHandlers;

namespace SaoTsea.Ds.Api.Core
{
	public class XpoAutoUpdateAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var dbHandler = context.HttpContext
			                       .RequestServices.GetService<DBHandlerCore>();
			int countValue = context.ActionArguments.Values.Count;
			var values = context.ActionArguments.Values.ToArray();
			var keys = context.ActionArguments.Keys.ToArray();
			if (countValue == 0)
			{
				return;
			}

			for (int i = 0; i < countValue; i++)
			{
				var value = values[i];
				var key = keys[i];
				if (value is INeedXpoBinding)
				{
					var propertys = value.GetType().GetProperties();
					if (propertys.Length > 1)
					{
						foreach (var property in propertys)
						{
							var mvalue = property.GetValue(value);
							if (mvalue == null)
							{
								continue;
							}

							if (mvalue.GetType().IsArray)
							{
								if (mvalue is XPLiteObject[])
								{
									UpdateOrInsertSet((object[]) mvalue, dbHandler);
								}
							}
							else
							{
								if (mvalue is IXPObject xpo)
								{
									property.SetValue(value, UpdateOrInsert(xpo, dbHandler));
								}
							}
						}
					}
				}
				else if (value is IXPObject xpo)
				{
					if (context.HttpContext.Request.Method.Equals("PUT") || context.HttpContext.Request.Method.Equals("PATCH"))
					{
						var roteIdData = context.RouteData.Values
						                        .FirstOrDefault(_ =>
							                        _.Key.Contains("id", StringComparison.OrdinalIgnoreCase));
						context.ActionArguments.TryGetValue(roteIdData.Key, out object xpoKey);

						xpo.ClassInfo.KeyProperty.SetValue(xpo, xpoKey);
					}

					context.ActionArguments[key] = UpdateOrInsert(xpo, dbHandler);
				}
				else if (value.GetType().IsArray)
				{
					UpdateOrInsertSet((object[]) value, dbHandler);
				}
			}
		}

		private IXPObject UpdateOrInsert(IXPObject xpo, DBHandlerCore db)
		{
			var value = xpo.ClassInfo.KeyProperty.GetValue(xpo);
			bool isUpdate = value is int i ? i > 0 : value is string s && !string.IsNullOrEmpty(s);
			if (isUpdate)
			{
				return db.UpdateObject((XPLiteObject)xpo);
			}

			return db.InsertObject((XPLiteObject)xpo);
		}

		private void UpdateOrInsertSet(object[] values, DBHandlerCore db)
		{
			int valueCount = values.Length;
			for (int i = 0; i < valueCount; i++)
			{
				if (values[i] is IXPObject xpo)
				{
					values[i] = UpdateOrInsert(xpo, db);
				}
			}
		}
	}
}
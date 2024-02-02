using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json.Linq;
using SaoTsea.Ds.Api.Models.ParamModels;

namespace SaoTsea.Ds.Api.Utility
{
	public static class Helper
	{
		public static void CopyFieldValue<T1, T2>(T1 source, T2 target)
		{
			var targetType = target.GetType();
			foreach (PropertyInfo property in source.GetType().GetProperties().Where(_ => _.CanWrite))
			{
				var field = targetType.GetField(property.Name);

				if (field == null) continue;
				
				field.SetValue(target, property.GetValue(source));
			}
		}

		public static void CopyPropertiesTo<TU>(JObject source, TU dest)
		{
			var sourceProps = source.Properties();
			var destProps = typeof(TU).GetProperties()
				.Where(x => x.CanWrite)
				.ToList();

			foreach (var sourceProp in sourceProps)
			{
				if (destProps.Any(x => x.Name == sourceProp.Name))
				{
					var p = destProps.First(x => x.Name == sourceProp.Name);
					if (p.CanWrite)
					{ // check if the property can be set or no.
						p.SetValue(dest, sourceProp.Value.ToObject(p.PropertyType), null);
					}
				}

			}
		}
		public static void CopyFieldsTo<TU>(object source, TU dest)
		{
			var sourceFields = source.GetType().GetFields();
			var destFields = typeof(TU).GetFields();

			foreach (var sField in sourceFields)
			{
				if (destFields.Any(x => x.Name == sField.Name))
				{
					var p = destFields.First(x => x.Name == sField.Name);
					p.SetValue(dest, sField.GetValue(source));
				}

			}
		}

		public static string GetBase64FromFile(string path)
		{
			string baseUploadPath = path;
			if (!File.Exists(baseUploadPath))
			{
				throw new IOException($"ไม่พบไฟล์ {baseUploadPath}");
			}

			return Convert.ToBase64String(File.ReadAllBytes(baseUploadPath));
		}

		public static IQueryable<T> OrderByCustom<T>(this IQueryable<T> source, string columnName, bool isAscending = true)
		{
			if (String.IsNullOrEmpty(columnName))
			{
				return source;
			}

			ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

			MemberExpression property = Expression.Property(parameter, columnName);
			LambdaExpression lambda = Expression.Lambda(property, parameter);

			string methodName = isAscending ? "OrderBy" : "OrderByDescending";

			Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
								  new Type[] { source.ElementType, property.Type },
								  source.Expression, Expression.Quote(lambda));

			return source.Provider.CreateQuery<T>(methodCallExpression);
		}

		public static string SetSearchColumn(FilterSearchListData filter)
		{
			string condition = "";
			if (filter.SearchMain?.Length > 0)
			{
				string conditionSearchMain = "";

				foreach (var item in filter.SearchMain)
				{
					conditionSearchMain = WhereUtility.Or(conditionSearchMain, $"Contains({item.ColumnName},'{(item.SearchWords ?? "").Trim()}')");

				}
				condition = WhereUtility.And(condition, $"({conditionSearchMain})");


			}
			if (filter.SearchColumns?.Length > 0)
			{
				string conditionSearchColumns = "";

				foreach (var item in filter.SearchColumns)
				{
					conditionSearchColumns = WhereUtility.And(conditionSearchColumns, $"Contains({item.ColumnName},'{(item.SearchWords ?? "").Trim()}')");
				}
				condition = WhereUtility.And(condition, $"({conditionSearchColumns})");

			}

			return condition;
		}

		public static string SetSearchColumnV2(FilterTaskListViewModel filter)
		{
			string condition = "";

			if (filter.SearchColumns?.Length > 0)
			{
				string conditionSearchColumns = "";

				foreach (var item in filter.SearchColumns)
				{
					conditionSearchColumns = WhereUtility.And(conditionSearchColumns, $"Contains({item.ColumnName},'{(item.SearchWords ?? "").Trim()}')");
				}
				condition = WhereUtility.And(condition, $"({conditionSearchColumns})");

			}

			return condition;
		}
	}
}

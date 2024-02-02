using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SaoTsea.Ds.Api.Utility
{
	public class WhereUtility
	{
		public static string BuildWhere(JObject param, bool noUseXpo = false)
		{
			if (!param.HasValues)
			{
				return "";
			}

			return param.Properties().Select(pty =>
			            {
				            var value = pty.Value;
				            var key = pty.Name;

				            if (key == "_custom")
				            {
					            return (string) value;
				            }

				            switch (value.Type)
				            {
					            case JTokenType.Integer:
					            case JTokenType.Float:
						            return $"{key}={value}";
					            case JTokenType.String:
						            if (string.IsNullOrEmpty((string) value))
						            {
							            return "";
						            }
						            else if (DateTime.TryParse(value.ToString(), out DateTime d))
						            {
							            if (noUseXpo)
							            {
								            return $"{key}='{value}'";
							            }

							            return $"GetDate({key})='{value}'";
						            }

						            return $"{key} LIKE '%{value}%'";
					            case JTokenType.Date:
						            if (noUseXpo)
						            {
							            return $"{key}='{value:yyyy-MM-dd}'";
						            }

						            return $"GetDate({key})='{value:yyyy-MM-dd}'";
					            default:
						            return "";
				            }
			            })
						.Where(_new => !string.IsNullOrEmpty(_new))
						.DefaultIfEmpty(string.Empty)
			            .Aggregate((_old, _new) => $"{_new} AND {_old}");
		}

		public static string And(string source, string condition)
		{
			string w = condition.Trim();

			if (string.IsNullOrEmpty(w))
			{
				return source;
			}

			string n = string.IsNullOrEmpty(source) ? w :
				source.EndsWith("and", StringComparison.OrdinalIgnoreCase) ? (" " + w) : (" AND " + w);
			return source?.Trim() + n;
		}

		public static string Or(string source, string condition)
		{
			string w = condition.Trim();

			if (string.IsNullOrEmpty(w))
			{
				return source;
			}

			string n = string.IsNullOrEmpty(source) ? w :
				source.EndsWith("or", StringComparison.OrdinalIgnoreCase) ? (" " + w) : (" OR " + w);
			return source?.Trim() + n;
		}
	}
}
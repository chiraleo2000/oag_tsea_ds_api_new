using System;
using Newtonsoft.Json.Linq;

namespace SaoTsea.Ds.Api.Utility
{
	public static class JsonHelper
	{
		public static string SerializeToMinimalJson(object obj)
		{
			return JObject.FromObject(obj).RemoveEmptyChildren().ToString();
		}

		public static JObject RemoveEmptyChildren(this JToken token)
		{
			if (token.Type == JTokenType.Object)
			{
				JObject copy = new JObject();
				foreach (JProperty prop in token.Children<JProperty>())
				{
					JToken child = prop.Value;
					if (child.HasValues)
					{
						child = child.RemoveEmptyChildren();
					}
					if (!child.IsEmptyOrDefault())
					{
						copy.Add(prop.Name, child);
					}
				}
				return copy;
			}
			//else if (token.Type == JTokenType.Array && token.HasValues)
			//{
			//	var tokenChildren = token.Children<JObject>().ToArray();
			//	for (int index = 0; index < tokenChildren.Length; index++)
			//	{
			//		((JArray) token)[index] = tokenChildren[index].RemoveEmptyChildren();
			//		index++;
			//	}

			//	return token;
			//}
			
			return null;
		}

		public static bool IsEmptyOrDefault(this JToken token)
		{
			if (token == null)
			{
				return true;
			}
			return (token.Type == JTokenType.Array && !token.HasValues) ||
			       (token.Type == JTokenType.Object && !token.HasValues) ||
			       (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
			       (token.Type == JTokenType.Boolean && token.Value<bool>() == false) ||
			       (token.Type == JTokenType.Integer && token.Value<int>() == 0) ||
			       (token.Type == JTokenType.Float && token.Value<double>() == 0.0) || 
			       (token.Type == JTokenType.Null);
		}
	}
}

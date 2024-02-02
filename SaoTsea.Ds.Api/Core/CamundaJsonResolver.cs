using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaoTsea.Ds.Api.Core
{
	public class CamundaJsonResolver: CamelCasePropertyNamesContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{

			JsonProperty property = base.CreateProperty( member, memberSerialization );

			if (property.PropertyName == "sorting")
			{
				property.ShouldSerialize = _ => false;
			}

			if( property.PropertyName == "sortOrder" )
			{
				property.ShouldSerialize = instance =>
				{
					return instance.GetType().GetFields()
						.Where(f => f.Name == "SortBy")
						.Any(f => f.GetValue(instance) != null);
				};
			}

			return property;
		}


	}
}

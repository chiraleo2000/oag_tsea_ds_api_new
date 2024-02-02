using Newtonsoft.Json.Serialization;

namespace SaoTsea.Ds.Api.Core
{
	public class UpperSnakeCasePropertyNamesContractResolver: CamelCasePropertyNamesContractResolver
	{
		public UpperSnakeCasePropertyNamesContractResolver()
		{
			NamingStrategy = new UpperCaseNamingStrategy
			{
				ProcessDictionaryKeys = true,
				OverrideSpecifiedNames = true
			};
		}
	}

	public class UpperCaseNamingStrategy : SnakeCaseNamingStrategy
	{
		protected override string ResolvePropertyName(string name)
		{
			string snake = base.ResolvePropertyName(name);
			return snake.ToUpperInvariant();
		}
	}
}

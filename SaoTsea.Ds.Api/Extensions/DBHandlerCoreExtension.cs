using System;
using DevExpress.Xpo;
using Microsoft.Extensions.DependencyInjection;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.Core.DataHandlers;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Extensions
{
	public static class DBHandlerCoreExtension
	{
		public static IServiceCollection AddDatabaseContext(this IServiceCollection serviceCollection,
			Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
		{
			void OptionsBuilder(DataLayerOptionsBuilder opt)
			{
				opt.UseEntityTypes(ConnectionHelper.GetPersistentTypes())
				   .UseNullableBehavior(NullableBehavior.AlwaysAllowNulls);
				customDataLayerOptionsBuilder?.Invoke(opt);
			}

			XpoDefault.TrackPropertiesModifications = true;
			serviceCollection
				.AddScoped<DBHandlerCore>()
				.AddScoped<ConditionContext>();
			return serviceCollection.AddXpoCustomSession<BetimesUntiOfWork>(true, OptionsBuilder);
		}
	}
}
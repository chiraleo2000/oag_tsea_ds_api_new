using System;
using System.Collections.Generic;
using System.Globalization;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.Extensions;
using SaoTsea.Ds.Api.Middleware;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection("AppSettings");
			var appSettings = appSettingsSection.Get<AppSetting>();
			services.AddDatabaseContext(opt =>
			{
                ConnectionStringParser helper = new ConnectionStringParser(Configuration.GetConnectionString(appSettings.DbConnectionName));
                string providerType = helper.GetPartByName("XpoProvider");
                if (providerType == "ODPManaged")
                {
                    BetimesOracleConnectionProvider.Register();
                }

				opt.UseConnectionString(Configuration.GetConnectionString(appSettings.DbConnectionName))
				   .UseAutoCreationOption(AutoCreateOption.None)
				   .UseConnectionPool(true);
				ConnectionProviderSql.GlobalDefaultCommandTimeout =
					TimeSpan.FromMinutes(3).Seconds;
			});

			services
				.AddSingleton(appSettings)
				.AddSingleton<ResourceUtility>()
				.AddSingleton<DataAccessService>()
				.AddScoped<UserProfileStore>()
                .AddHttpClient();
			
			services.AddTokenBearer(opt =>
			{
                opt.RequireHttpsMetadata = false;
				opt.Authority = appSettings.IdentityServer.Host;
                opt.Audience = "account";
            });

            services.AddCors(cfg => cfg.AddPolicy(
                "ClientDomain",
                b => b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
			));


			//Setup mail
			services.AddControllers()
			        .AddMvcOptions(opt =>
			        {
				        opt.ModelBinderProviders.Insert(0, new XpoModelBinderProvider());
				        opt.Filters.Add<ResultWarperActionFilter>();
				        opt.ModelMetadataDetailsProviders.Add(
					        new SuppressChildValidationMetadataProvider(typeof(XPBaseObject)));
			        })
			        .AddNewtonsoftJson();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseCors("ClientDomain");
			app.ConfigureExceptionHandler();
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(ci),
				SupportedCultures = new List<CultureInfo> {ci},
				SupportedUICultures = new List<CultureInfo> {ci}
			});
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

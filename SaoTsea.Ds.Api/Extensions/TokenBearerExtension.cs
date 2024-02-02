using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Extensions
{
	public static class TokenBearerExtension
	{
		public static IServiceCollection AddTokenBearer(this IServiceCollection serviceCollection,
			Action<JwtBearerOptions> options = null)
		{
			serviceCollection.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{
				opt.EventsType = typeof(TokenBearerEvents);
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = "",
					ValidAudience = "",
					IssuerSigningKey = null,
					ClockSkew = TimeSpan.Zero
				};

				options?.Invoke(opt);
			});

			serviceCollection.AddScoped<TokenBearerEvents>();
			serviceCollection.AddScoped<UserPayload>();
			serviceCollection.AddSingleton<TokenFactory>();
			return serviceCollection;
		}
	}
}

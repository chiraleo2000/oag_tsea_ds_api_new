using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
	public class TokenFactory
	{
		private readonly AppSetting _settings;
		private readonly JwtSecurityTokenHandler _tokenHandler;

		public TokenFactory(AppSetting settings)
		{
			_settings = settings;
			_tokenHandler = new JwtSecurityTokenHandler();
		}

		public string GenerateUserToken(UserPayload user)
		{
			Type contentType = user.GetType();
			var contentProperties = contentType.GetProperties();
			var claim = new List<Claim>(contentProperties.Length);

			for (int i = 0; i < contentProperties.Length; i++)
			{
				var properyty = contentProperties[i];

				if (Attribute.IsDefined(properyty, typeof(ExcludeFromResultSetAttribute)))
				{
					continue;
				}

				var value = properyty.GetValue(user);
				if (value != null)
				{
					claim.Add(new Claim(properyty.Name, value.ToString()));
				}
			}

			return GenerateToken(claim);
		}

		public string GenerateToken(List<Claim> claims)
		{
			if (claims is null) throw new NullReferenceException(nameof(claims));

			var secureKey = new SymmetricSecurityKey(
				System.Text.Encoding.UTF8.GetBytes(_settings.Jwt.Secret));
			var signed = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = _settings.Jwt.Issuer,
				Audience = _settings.Jwt.Issuer,
				Subject = new ClaimsIdentity(claims),
				IssuedAt = DateTime.UtcNow,
				NotBefore = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddMinutes(_settings.Jwt.Expires),
				SigningCredentials = signed
			};
			return _tokenHandler.WriteToken(
				_tokenHandler.CreateJwtSecurityToken(tokenDescriptor));
		}

		public string GenerateRefreshToken()
		{
			using var rng = new RNGCryptoServiceProvider();
			byte[] token = new byte[32];
			rng.GetBytes(token);
			return Convert.ToBase64String(token);
		}

		public JwtSecurityToken GetTokenInfo(string token)
		{
			return _tokenHandler.ReadJwtToken(token);
		}

		public bool CanRefreshToken(JwtSecurityToken token)
		{
			var expireExtend = token.ValidTo.AddMinutes(_settings.Jwt.RefreshTokenExpires);
			return DateTime.UtcNow < expireExtend;
		}

		public bool IsTokenExpired(JwtSecurityToken token)
		{
			return DateTime.UtcNow > token.ValidTo;
		}
	}
}

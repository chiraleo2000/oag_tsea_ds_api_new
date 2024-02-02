namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class AppSetting
	{
		public string DbConnectionName { get; set; }
		public string ResourcePath { get; set; }
		public RedisConfig Redis { get; set; }
		public BpmsConfig Bpms { get; set; }
		public MailConfig Mail { get; set; }
		public KeyStore Keys { get; set; }
		public JwtSettings Jwt { get; set; }
		public PkiConfig Pki { get; set; }
		public DGAConfig DGA { get; set; }
		public IdentityServerConfig IdentityServer { get; set; }
        public SSOConfig SSO { get; set; }

    }

    public class SSOConfig
    {
        public string Host { get; set; }
        public string Endpoint { get; set; }
        public string Token { get; set; }
        public bool IsByPass { get; set; }
    }

    public class RedisConfig
	{
		public string Host { get; set; }
		public string Prefix { get; set; }
		public string Password { get; set; }
	}

	public class BpmsConfig
	{
		public string Type { get; set; }
		public string Host { get; set; }
	}
	public class BackendConfig
	{
		public string Host { get; set; }
	}

	public class MailConfig
	{
		public string Host { get; set; }
		public int Port { get; set; }
		public string From { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class JwtSettings
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public int Expires { get; set; }
		public int RefreshTokenExpires { get; set; }
	}

	public class KeyStore
	{
		public string IdsSecretKey { get; set; }
		public string EncryptKey { get; set; }
		public string ReCaptcha { get; set; }
		public string ResetPassword { get; set; }
	}

	public class PkiConfig
	{
		public string KeyStorage { get; set; }
		public string PinCode { get; set; }
		public string KeyTool { get; set; }
	}

	public class IdentityServerConfig
	{
		public string Host { get; set; }
		public string ApiHost { get; set; }
		public string OidcApiName { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string AdminUser { get; set; }
		public string AdminPassword { get; set; }
	}

	public class DGAConfig
	{
		public string Host { get; set; }
	}
}

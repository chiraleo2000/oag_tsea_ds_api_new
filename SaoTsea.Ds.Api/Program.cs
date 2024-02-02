using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SaoTsea.Ds.Api;

namespace oag_tsea_ds_api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{

					webBuilder
						.UseUrls("http://*:3543")
						.UseKestrel()
						//.UseUrls("http://localhost:3542")
						//.UseIISIntegration()
						.UseStartup<Startup>();
				});
	}
}

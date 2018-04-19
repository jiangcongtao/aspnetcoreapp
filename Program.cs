using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {	

            var host = BuildWebHost(args);
			host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
			var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
			var url = config["ASPNETCORE_URLS"]?? "http://*:8080";

            return new WebHostBuilder().UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
				.UseUrls(url)
                .Build();
		}
    }
}

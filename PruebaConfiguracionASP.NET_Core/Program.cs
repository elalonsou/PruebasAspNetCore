using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PruebaConfiguracionASP.NET_Core
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
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration(configuration => {
                    configuration.AddJsonFile("configPersonalizada.json", optional:true, reloadOnChange:true);
                    if (args != null)
                    {
                        configuration.AddCommandLine(args);
                    }
                   
                    configuration.AddEnvironmentVariables();
                    //Con Build nos permite generar la configuracion y usarla mas adelante, por ejemplo si necesitamos alguna configuracion
                    IConfiguration configBuild = configuration.Build();
                    configuration.AddUserSecrets<Program>();
                });
    }
}

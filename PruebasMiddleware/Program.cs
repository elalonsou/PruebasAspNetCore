using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace PruebasMiddleware
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
                })
                .ConfigureLogging((hostingContext,logging) =>
                    {
                        logging.AddConsole();
                        logging.AddDebug();
                        //Ejemplo de filto
                        //El segundo AddFilter especifica el proveedor de depuración mediante su nombre de tipo. 
                        //El primer AddFilter se aplica a todos los proveedores, dado que no especifica un tipo de proveedor.
                       //logging.AddFilter("System", LogLevel.Debug);
                       //logging.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
                    }
                );
    }
}

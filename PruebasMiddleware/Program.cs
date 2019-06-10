using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
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
                        logging.ClearProviders();
                        //Para coger la configuracion del fichero de configuración.
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                        logging.AddEventSourceLogger();
                        //Esta extension es de un paquete serialicer
                        logging.AddFile(hostingContext.Configuration.GetSection("Logging"));
                        
                        
                        //Ejemplo de filto
                        //El segundo AddFilter especifica el proveedor de depuración mediante su nombre de tipo. 
                        //El primer AddFilter se aplica a todos los proveedores, dado que no especifica un tipo de proveedor.
                        //logging.AddFilter("System", LogLevel.Debug);
                        //logging.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
                    }
                );
    }
}

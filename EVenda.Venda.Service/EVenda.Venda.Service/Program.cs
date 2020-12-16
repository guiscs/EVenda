using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace EVenda.Venda.Service
{
    public class Program
    {
        public IConfiguration Configuration { get; }

        public Program()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.ConfigureDependencies();
                    services.AddHostedService<Worker>();
                });
    }
}

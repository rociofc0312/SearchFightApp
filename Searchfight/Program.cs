using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Searchfight.Extensions;
using Serilog;
using System.IO;

namespace Searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = BuildConfiguration();
            ConfigureLogging(configuration);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddConfiguration(configuration)
                        .AddCustomServices()
                        .AddCustomApiClients();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<SearchFight>(host.Services);
            svc.Run(args);
        }

        static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();
        }

        static void ConfigureLogging(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses;
using Searchfight.Services.ApiClient;
using Searchfight.Services.ApiClient.Interfaces;

namespace Searchfight.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<SearchFight>();
            return services;
        }

        public static IServiceCollection AddCustomApiClients(this IServiceCollection services)
        {
            services.AddHttpClient<IGenericSearchApiClient<GoogleSearchApiResponse>, GoogleSearchApiClient>();
            return services;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleApi>(configuration.GetSection("SearchEngines:0"));
            return services;
        }
    }
}

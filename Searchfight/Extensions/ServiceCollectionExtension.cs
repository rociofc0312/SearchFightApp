using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Searchfight.IServices;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses;
using Searchfight.Services;
using Searchfight.Services.ApiClient;
using Searchfight.Services.ApiClient.Interfaces;

namespace Searchfight.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<SearchFight>();
            services.AddTransient<ISearchFightService, SearchFightService>();
            services.AddTransient<IQueryReportService, QueryReportService>();
            return services;
        }

        public static IServiceCollection AddCustomApiClients(this IServiceCollection services)
        {
            services.AddTransient<IGenericSearchApiClient, GoogleSearchApiClient>();
            services.AddTransient<IGenericSearchApiClient, BingSearchApiClient>();
            return services;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleApi>(configuration.GetSection("SearchEngines:0"));
            services.Configure<BingApi>(configuration.GetSection("SearchEngines:1"));
            return services;
        }
    }
}

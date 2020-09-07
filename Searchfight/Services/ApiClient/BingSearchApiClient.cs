using Microsoft.Extensions.Options;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses;
using Searchfight.Services.ApiClient.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight.Services.ApiClient
{
    public class BingSearchApiClient : BaseSearchApiClient, IGenericSearchApiClient<BingSearchApiResponse>
    {
        private readonly BingApi _bingSettings;
        public BingSearchApiClient(HttpClient client, IOptions<BingApi> bingSettings) : base(client)
        {
            _bingSettings = bingSettings.Value;
            BaseUri = $"{_bingSettings.Host}";
        }

        public async Task<BingSearchApiResponse> GetResults(string query)
        {
            var request = new UriBuilder(BaseUri);
            request.Query = $"key={_bingSettings.Key}&q={query}";
            return await ExecuteGetAsync<BingSearchApiResponse>(request.Uri);
        }
    }
}

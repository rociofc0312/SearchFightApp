using Microsoft.Extensions.Options;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses;
using Searchfight.Services.ApiClient.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight.Services.ApiClient
{
    public class GoogleSearchApiClient : BaseSearchApiClient, IGenericSearchApiClient<GoogleSearchApiResponse>
    {
        private readonly GoogleApi _googleSettings;
        public GoogleSearchApiClient(HttpClient client, IOptions<GoogleApi> googleSettings) : base(client)
        {
            _googleSettings = googleSettings.Value;
            BaseUri = $"{_googleSettings.Host}";
        }

        public async Task<GoogleSearchApiResponse> GetResults(string query)
        {
            var request = new UriBuilder(BaseUri);
            request.Query = $"key={_googleSettings.Key}&cx={_googleSettings.Cx}&q={query}";
            return await ExecuteGetAsync<GoogleSearchApiResponse>(request.Uri);
        }
    }
}

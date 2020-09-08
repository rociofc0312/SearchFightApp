using Microsoft.Extensions.Options;
using RestSharp;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses.ApiResponse;
using Searchfight.Services.ApiClient.Interfaces;

namespace Searchfight.Services.ApiClient
{
    public class BingSearchApiClient : BaseSearchApiClient, IGenericSearchApiClient
    {
        private readonly string Cc;
        private readonly IOptions<BingApi> _bingApi;

        public BingSearchApiClient(IOptions<BingApi> bingApi) : base(bingApi.Value)
        {
            _bingApi = bingApi;
            Cc = _bingApi.Value.Cc;
        }
        public string Name { get => _bingApi.Value.Name; }

        public long GetResults(string query)
        {
            var request = new RestRequest($"/search?q={query}&customconfig={Cc}");
            request.AddHeader("Ocp-Apim-Subscription-Key", Key);
            request.AddHeader("Retry-After", "1");

            var response = SendRequest<BingSearchApiResponse>(Method.GET, request);
            return response != null ? response.WebPages.TotalEstimatedMatches : 0;
        }
    }
}

using Microsoft.Extensions.Options;
using RestSharp;
using Searchfight.Models;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses;
using Searchfight.Services.ApiClient.Interfaces;

namespace Searchfight.Services.ApiClient
{
    public class BingSearchApiClient : BaseSearchApiClient, IGenericSearchApiClient
    {
        private string Cc;
        public BingSearchApiClient(IOptions<BingApi> bingSettings)
        {
            BaseUrl = bingSettings.Value.Host;
            Key = bingSettings.Value.Key;
            Cc = bingSettings.Value.Cc;
            Name = bingSettings.Value.Name;
        }

        public QueryResult GetResults(string query)
        {
            var request = new RestRequest($"/search?q={query}&customconfig={Cc}");
            request.AddHeader("Ocp-Apim-Subscription-Key", Key);
            request.AddHeader("Retry-After", "1");

            var response = SendRequest<BingSearchApiResponse>(Method.GET, request);
            var searchResult = new QueryResult
            {
                Engine = Name,
                Query = query,
                TotalResults = response.WebPages.TotalEstimatedMatches
            };
            return searchResult;
        }
    }
}

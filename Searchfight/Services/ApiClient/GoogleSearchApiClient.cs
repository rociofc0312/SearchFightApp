using Microsoft.Extensions.Options;
using RestSharp;
using Searchfight.Models;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses;
using Searchfight.Services.ApiClient.Interfaces;
using System;

namespace Searchfight.Services.ApiClient
{
    public class GoogleSearchApiClient : BaseSearchApiClient, IGenericSearchApiClient
    {
        private string Cx;
        public GoogleSearchApiClient(IOptions<GoogleApi> googleApi)
        {
            BaseUrl = googleApi.Value.Host;
            Key = googleApi.Value.Key;
            Cx = googleApi.Value.Cx;
            Name = googleApi.Value.Name;
        }

        public QueryResult GetResults(string query)
        {
            var request = new RestRequest($"?key={Key}&cx={Cx}&q={query}");

            var response = SendRequest<GoogleSearchApiResponse>(Method.GET, request);
            var searchResult = new QueryResult
            {
                Engine = Name,
                Query = query,
                TotalResults = Convert.ToInt64(response.SearchInformation.TotalResults)
            };
            return searchResult;
        }
    }
}

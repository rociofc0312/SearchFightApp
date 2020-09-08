using Microsoft.Extensions.Options;
using RestSharp;
using Searchfight.Models.Configurations;
using Searchfight.Models.Responses.ApiResponse;
using Searchfight.Services.ApiClient.Interfaces;
using System;

namespace Searchfight.Services.ApiClient
{
    public class GoogleSearchApiClient : BaseSearchApiClient, IGenericSearchApiClient
    {
        private readonly string Cx;
        private readonly IOptions<GoogleApi> _googleApi;

        public GoogleSearchApiClient(IOptions<GoogleApi> googleApi) : base(googleApi.Value)
        {
            _googleApi = googleApi;
            Cx = _googleApi.Value.Cx;
        }

        public string Name { get => _googleApi.Value.Name; }

        public long GetResults(string query)
        {
            var request = new RestRequest($"?key={Key}&cx={Cx}&q={query}");
            var response = SendRequest<GoogleSearchApiResponse>(Method.GET, request);
            return response != null ? Convert.ToInt64(response.SearchInformation.TotalResults) : 0;
        }
    }
}

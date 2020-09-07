using Searchfight.Models.Responses;
using Searchfight.Services.ApiClient.Interfaces;
using System;
using System.Threading.Tasks;

namespace Searchfight
{
    public class SearchFight
    {
        private readonly IGenericSearchApiClient<GoogleSearchApiResponse> _googleApiClient;
        public SearchFight(IGenericSearchApiClient<GoogleSearchApiResponse> googleApiClient)
        {
            _googleApiClient = googleApiClient;
        }
        public async Task RunAsync()
        {
            var result = await _googleApiClient.GetResults("lectures");
            Console.WriteLine("Result: " + result.SearchInformation.TotalResults);
        }
    }
}

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Searchfight.Services.ApiClient
{
    public class BaseSearchApiClient
    {
        protected readonly HttpClient _client;
        protected string BaseUri;

        public BaseSearchApiClient(HttpClient client)
        {
            _client = client;
        }

        protected async Task<T> ExecuteGetAsync<T>(Uri uri) where T:class
        {
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T>(result, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
                return null;
        }
    }
}

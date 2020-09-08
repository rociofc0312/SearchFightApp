using RestSharp;
using Searchfight.Models.Configurations;
using System.Net;

namespace Searchfight.Services.ApiClient
{
    public class BaseSearchApiClient
    {
        protected string BaseUrl;
        protected string Key;
        public BaseSearchApiClient(BaseApi baseApi)
        {
            BaseUrl = baseApi.Host;
            Key = baseApi.Key;
        }

        protected T SendRequest<T>(Method method, RestRequest request, object body = null) where T : class
        {
            var client = new RestClient(BaseUrl);
            if (body != null)
                request.AddJsonBody(body);
            IRestResponse<T> response = client.Execute<T>(request, method);
            return response.StatusCode != HttpStatusCode.OK ? null : response.Data;
        }
    }
}

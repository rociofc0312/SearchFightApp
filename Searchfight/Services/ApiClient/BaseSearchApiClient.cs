using RestSharp;
using System;

namespace Searchfight.Services.ApiClient
{
    public class BaseSearchApiClient
    {
        protected string BaseUrl;
        protected string Key;
        protected string Name;

        protected T SendRequest<T>(Method method, RestRequest request, object body = null) where T : new()
        {
            var client = new RestClient(BaseUrl);
            if (body != null)
                request.AddJsonBody(body);
            IRestResponse<T> response = client.Execute<T>(request, method);
            return response.Data;
        }
    }
}

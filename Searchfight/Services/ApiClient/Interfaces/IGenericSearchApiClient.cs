using Searchfight.Models;

namespace Searchfight.Services.ApiClient.Interfaces
{
    public interface IGenericSearchApiClient
    {
        QueryResult GetResults(string query);
    }
}

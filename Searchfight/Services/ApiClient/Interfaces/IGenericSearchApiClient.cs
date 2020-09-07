using System.Threading.Tasks;

namespace Searchfight.Services.ApiClient.Interfaces
{
    public interface IGenericSearchApiClient<T>
    {
        Task<T> GetResults(string query);
    }
}

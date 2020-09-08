namespace Searchfight.Services.ApiClient.Interfaces
{
    public interface IGenericSearchApiClient
    {
        string Name { get; }
        long GetResults(string query);
    }
}

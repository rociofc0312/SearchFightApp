namespace Searchfight.Services.ApiClient.Interfaces
{
    public interface ICommonSearchApiClient
    {
        string Name { get; }
        long GetResults(string query);
    }
}

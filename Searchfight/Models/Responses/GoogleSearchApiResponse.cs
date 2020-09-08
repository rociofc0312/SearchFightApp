namespace Searchfight.Models.Responses
{
    public class GoogleSearchApiResponse
    {
        public SearchInformation SearchInformation { get; set; }
    }

    public class SearchInformation
    {
        public string TotalResults { get; set; }
    }
}

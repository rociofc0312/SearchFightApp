namespace Searchfight.Models.Responses.ApiResponse
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

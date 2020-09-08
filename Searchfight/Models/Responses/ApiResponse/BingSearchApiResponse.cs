namespace Searchfight.Models.Responses.ApiResponse
{
    public class BingSearchApiResponse
    {
        public WebPages WebPages { get; set; }
    }

    public class WebPages
    {
        public long TotalEstimatedMatches { get; set; }
    }
}

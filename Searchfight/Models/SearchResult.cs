namespace Searchfight.Models
{
    public class QueryResult
    {
        public string Engine { get; set; }
        public string Query { get; set; }
        public long TotalResults { get; set; }
    }
}

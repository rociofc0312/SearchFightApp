using System.Collections.Generic;

namespace Searchfight.Models.Responses.ServiceResponse
{
    public class QueryReport
    {
        public List<QueryResult> QueryResults { get; set; }
        public List<QueryResult> QueryWinners { get; set; }
        public string TotalWinner { get; set; }
    }
}

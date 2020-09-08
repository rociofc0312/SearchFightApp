using Searchfight.Models;
using System.Collections.Generic;

namespace Searchfight.IServices
{
    public interface ISearchFightService
    {
        List<QueryResult> SearchQueries(List<string> queries);
        List<QueryResult> QueryWinnersBySearchEngine(List<QueryResult> searchResults);
        string GetTotalWinner(List<QueryResult> searchResults);
    }
}

using Searchfight.IServices;
using Searchfight.Models.Responses.ServiceResponse;
using Searchfight.Services.ApiClient.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Services
{
    public class SearchFightService : ISearchFightService
    {
        private readonly IEnumerable<ICommonSearchApiClient> _searchApiClients;
        public SearchFightService(IEnumerable<ICommonSearchApiClient> searchApiClients)
        {
            _searchApiClients = searchApiClients;
        }

        public List<QueryResult> SearchQueries(List<string> queries)
        {
            var list = new List<QueryResult>();
            foreach(var query in queries)
            {
                foreach(var client in _searchApiClients)
                {
                    var queryResult = new QueryResult() {
                        Engine = client.Name,
                        Query = query,
                        TotalResults = client.GetResults(query)
                    };
                    list.Add(queryResult);
                }
            }
            return list;
        }

        public List<QueryResult> QueryWinnersBySearchEngine(List<QueryResult> queryResults)
        {
            var winners = new List<QueryResult>();
            var groupedWinners = queryResults.GroupBy(x => x.Engine).ToList();
            foreach(var winner in groupedWinners)
            {
                winners.Add(winner.Aggregate((i1, i2) => i1.TotalResults > i2.TotalResults ? i1 : i2));
            }
            return winners;
        }

        public string GetTotalWinner(List<QueryResult> queryResults)
        {
            var groupedResults = queryResults.GroupBy(x => x.Query)
                .Select(g => new { Id = g.Key, TotalResults = g.Sum(y => y.TotalResults)});

            var totalWinner = groupedResults.Aggregate((i1, i2) => i1.TotalResults > i2.TotalResults ? i1 : i2);
            return totalWinner.Id;
        }
    }
}

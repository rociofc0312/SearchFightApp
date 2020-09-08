using Searchfight.IServices;
using Searchfight.Models.Responses.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Services
{
    public class QueryReportService : IQueryReportService
    {
        public ISearchFightService _searchFightService { get; }

        public QueryReportService(ISearchFightService searchFightService)
        {
            _searchFightService = searchFightService;
        }

        public QueryReport ExecuteSearchFight(List<string> args)
        {
            var queryReport = new QueryReport();
            queryReport.QueryResults = _searchFightService.SearchQueries(args);
            queryReport.QueryWinners = _searchFightService.QueryWinnersBySearchEngine(queryReport.QueryResults);
            queryReport.TotalWinner = _searchFightService.GetTotalWinner(queryReport.QueryResults);
            return queryReport;
        }

        public void BuildConsoleResponse(QueryReport queryReport)
        {
            BuildResults(queryReport.QueryResults);
            BuildWinners(queryReport.QueryWinners);
            BuildTotalWinner(queryReport.TotalWinner);
        }

        private void BuildResults(List<QueryResult> results)
        {
            var resultString = results.GroupBy(x => x.Query)
                .Select(y => $"{y.Key}: {string.Join(" ", y.Select(y => $"{y.Engine}: {y.TotalResults}"))}");
            resultString.ToList().ForEach(x => Console.WriteLine(x));
        }

        private void BuildWinners(List<QueryResult> winners)
        {
            var resultString = winners.Select(x => $"{x.Engine} winner: {x.Query}");
            resultString.ToList().ForEach(x => Console.WriteLine(x));
        }

        private void BuildTotalWinner(string totalWinner)
        {
            Console.WriteLine($"Total winner: {totalWinner}");
        }
    }
}

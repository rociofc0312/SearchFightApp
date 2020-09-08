using Searchfight.IServices;
using Searchfight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Services
{
    public class ConsolePrintService : IConsolePrintService
    {
        public void BuildConsoleResponse(List<QueryResult> results, List<QueryResult> winners, string totalWinner)
        {
            BuildResults(results);
            BuildWinners(winners);
            BuildTotalWinner(totalWinner);
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

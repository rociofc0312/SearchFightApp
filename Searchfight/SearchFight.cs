using Searchfight.IServices;
using System;
using System.Linq;

namespace Searchfight
{
    public class SearchFight
    {
        public ISearchFightService _searchFightService { get; }
        public IConsolePrintService _consolePrintService { get; }

        public SearchFight(ISearchFightService searchFightService, IConsolePrintService consolePrintService)
        {
            _searchFightService = searchFightService;
            _consolePrintService = consolePrintService;
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
                Console.ReadLine()?.Split(" ");
            ExecuteSearchFight(args);
        }

        private void ExecuteSearchFight(string[] args)
        {
            var results = _searchFightService.SearchQueries(args.ToList());
            var winners = _searchFightService.QueryWinnersBySearchEngine(results);
            var totalWinner = _searchFightService.GetTotalWinner(results);

            _consolePrintService.BuildConsoleResponse(results, winners, totalWinner);
        }
    }
}

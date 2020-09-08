using Searchfight.IServices;
using Serilog;
using System;
using System.Linq;

namespace Searchfight
{
    public class SearchFight
    {
        public IQueryReportService _queryReportService { get; }

        public SearchFight(IQueryReportService consolePrintService)
        {
            _queryReportService = consolePrintService;
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
                Console.ReadLine()?.Split(" ");
            try
            {
                var report = _queryReportService.ExecuteSearchFight(args.ToList());
                _queryReportService.BuildConsoleResponse(report);
            }
            catch (Exception ex)
            {
                Log.Error($"Error found: {ex}");
            }
        }
    }
}

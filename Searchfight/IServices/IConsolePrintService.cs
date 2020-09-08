using Searchfight.Models;
using System.Collections.Generic;

namespace Searchfight.IServices
{
    public interface IConsolePrintService
    {
        void BuildConsoleResponse(List<QueryResult> results, List<QueryResult> winners, string totalWinner);
    }
}

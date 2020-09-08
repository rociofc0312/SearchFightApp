using Searchfight.Models;
using Searchfight.Models.Responses.ServiceResponse;
using System.Collections.Generic;

namespace Searchfight.IServices
{
    public interface IQueryReportService
    {
        QueryReport ExecuteSearchFight(List<string> args);
        void BuildConsoleResponse(QueryReport queryReport);
    }
}

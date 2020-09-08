using FluentAssertions;
using NUnit.Framework;
using Searchfight.Services;
using Searchfight.Services.ApiClient.Interfaces;
using Searchfight.Tests.MockBuilders;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Tests
{
    [TestFixture]
    public class SearchFightServiceTests
    {
        private CommonSearchApiClientMockBuilder _googleSearchApiClientMockBuilder;
        private CommonSearchApiClientMockBuilder _bingSearchApiClientMockBuilder;
        private QueryReportService _queryReportService;

        [SetUp]
        public void Setup()
        {
            _googleSearchApiClientMockBuilder = new CommonSearchApiClientMockBuilder();
            _bingSearchApiClientMockBuilder = new CommonSearchApiClientMockBuilder();
            IEnumerable<ICommonSearchApiClient> clients = BuildIEnumerableSearchClients();
            var searchFightService = new SearchFightService(clients);
            _queryReportService = new QueryReportService(searchFightService);
        }

        private List<ICommonSearchApiClient> BuildIEnumerableSearchClients()
        {
            return new List<ICommonSearchApiClient>
            {
                _googleSearchApiClientMockBuilder.WithEngineName("Google").Build(),
                _bingSearchApiClientMockBuilder.WithEngineName("Bing").Build()
            };
        }

        [Test]
        public void SearchQueries_ValidQuery_ReturnValidReportData()
        {
            _googleSearchApiClientMockBuilder.WithValidLongData();
            _bingSearchApiClientMockBuilder.WithValidLongData();

            var report = _queryReportService.ExecuteSearchFight(new List<string> { ".NET", "Java" });

            report.Should().NotBeNull();
            report.QueryResults.Count.Should().Be(4);
            report.QueryWinners.Count.Should().Be(2);
            report.TotalWinner.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void QueryWinnersBySearchEngine_QueryWithNoResultsInOneEngine_ReturnValidReportData()
        {
            _bingSearchApiClientMockBuilder.WithValidLongData();
            _googleSearchApiClientMockBuilder.WithNoData();

            var report = _queryReportService.ExecuteSearchFight(new List<string> { "no results query", "Java" });

            report.Should().NotBeNull();
            report.QueryWinners.First(x => x.Engine == "Google").Query.Should().Be("Java");
        }
    }
}
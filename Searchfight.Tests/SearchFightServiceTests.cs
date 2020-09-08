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
        private GoogleSearchApiClientMockBuilder _googleSearchApiClientMockBuilder;
        private BingSearchApiClientMockBuilder _bingSearchApiClientMockBuilder;
        private QueryReportService _queryReportService;

        [SetUp]
        public void Setup()
        {
            _googleSearchApiClientMockBuilder = new GoogleSearchApiClientMockBuilder();
            _bingSearchApiClientMockBuilder = new BingSearchApiClientMockBuilder();
            IEnumerable<IGenericSearchApiClient> clients = new List<IGenericSearchApiClient> { _googleSearchApiClientMockBuilder.Build(), _bingSearchApiClientMockBuilder.Build() };
            var searchFightService = new SearchFightService(clients);
            _queryReportService = new QueryReportService(searchFightService);
        }

        [Test]
        public void SearchQueries_ValidQuery_ReturnValidReportData()
        {
            _googleSearchApiClientMockBuilder.WithEngineName().WithValidLongData();
            _bingSearchApiClientMockBuilder.WithEngineName().WithValidLongData();

            var report = _queryReportService.ExecuteSearchFight(new List<string> { ".NET", "Java" });

            report.Should().NotBeNull();
            report.QueryResults.Count.Should().Be(4);
            report.QueryWinners.Count.Should().Be(2);
            report.TotalWinner.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void QueryWinnersBySearchEngine_QueryWithNoResultsInOneEngine_ReturnValidReportData()
        {
            _bingSearchApiClientMockBuilder.WithEngineName().WithValidLongData();
            _googleSearchApiClientMockBuilder.WithEngineName().WithNoData();

            var report = _queryReportService.ExecuteSearchFight(new List<string> { "no results query", "Java" });

            report.Should().NotBeNull();
            report.QueryWinners.First(x => x.Engine == "Google").Query.Should().Be("Java");
        }
    }
}
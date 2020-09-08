using Moq;
using Searchfight.Services.ApiClient.Interfaces;
using System;

namespace Searchfight.Tests.MockBuilders
{
    public class CommonSearchApiClientMockBuilder
    {
        private Mock<ICommonSearchApiClient> _client;

        public CommonSearchApiClientMockBuilder()
        {
            _client = new Mock<ICommonSearchApiClient>();
        }

        public CommonSearchApiClientMockBuilder WithValidLongData()
        {
            _client.Setup(x => x.GetResults(It.IsAny<string>()))
                .Returns(new Random().Next(1, 100));
            return this;
        }

        public CommonSearchApiClientMockBuilder WithNoData()
        {
            _client.Setup(x => x.GetResults(It.Is<string>(y => y == "no results query")))
                .Returns(0);
            return this;
        }

        public CommonSearchApiClientMockBuilder WithEngineName(string name)
        {
            _client.Setup(x => x.Name)
                .Returns(name);
            return this;
        }

        public ICommonSearchApiClient Build()
        {
            return _client.Object;
        }
    }
}

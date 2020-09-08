using Moq;
using Searchfight.Services.ApiClient.Interfaces;
using System;

namespace Searchfight.Tests.MockBuilders
{
    public class GoogleSearchApiClientMockBuilder
    {
        private Mock<IGenericSearchApiClient> _client;

        public GoogleSearchApiClientMockBuilder()
        {
            _client = new Mock<IGenericSearchApiClient>();
        }

        public GoogleSearchApiClientMockBuilder WithValidLongData()
        {
            _client.Setup(x => x.GetResults(It.IsAny<string>()))
                .Returns(new Random().Next(1, 100));
            return this;
        }

        public GoogleSearchApiClientMockBuilder WithNoData()
        {
            _client.Setup(x => x.GetResults(It.Is<string>(y => y == "no results query")))
                .Returns(0);
            return this;
        }

        public GoogleSearchApiClientMockBuilder WithEngineName()
        {
            _client.Setup(x => x.Name)
                .Returns("Google");
            return this;
        }

        public IGenericSearchApiClient Build()
        {
            return _client.Object;
        }
    }
}

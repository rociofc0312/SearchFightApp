using Moq;
using Searchfight.Services.ApiClient.Interfaces;
using System;

namespace Searchfight.Tests.MockBuilders
{
    public class BingSearchApiClientMockBuilder
    {
        private Mock<IGenericSearchApiClient> _client;

        public BingSearchApiClientMockBuilder()
        {
            _client = new Mock<IGenericSearchApiClient>();
        }

        public BingSearchApiClientMockBuilder WithValidLongData()
        {
            _client.Setup(x => x.GetResults(It.IsAny<string>()))
                .Returns((string x) => new Random().Next(1, 100));
            return this;
        }

        public BingSearchApiClientMockBuilder WithEngineName()
        {
            _client.Setup(x => x.Name)
                .Returns("Bing");
            return this;
        }

        public IGenericSearchApiClient Build()
        {
            return _client.Object;
        }
    }
}

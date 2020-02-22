namespace StarshipResupply.Data.Gateway.Tests.Starship
{
    using AutoFixture;
    using FluentAssertions;
    using StarshipResupply.Data.Gateway.Settings;
    using StarshipResupply.Data.Gateway.Starship;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class HttpMessageHandlerFake : HttpMessageHandler
    {
        private const string FakeJson = "{ 'count': 37, 'next': 'https://swapi.co/api/starships/?page=2', 'previous': null, 'results': [ { 'name': 'Executor', 'model': 'Executor-class star dreadnought', 'consumables': '6 years', 'MGLT': '40' } ]}'";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(FakeJson)
            };

            return await Task.FromResult(responseMessage);
        }
    }

    public sealed class StarshipGatewayTests
    {
        private const string FakeEndpoint = "http://localhost:1234";
        private readonly Fixture fixture;
        private readonly GatewaySettings gatewaySettings;
        private readonly HttpClient httpClient;

        public StarshipGatewayTests()
        {
            fixture = new Fixture();
            httpClient = new HttpClient(new HttpMessageHandlerFake());
        }

        [Fact]
        public async Task Calculate_CallsService_ReturnValue()
        {
            //Arrange
            var gatewaySettings = fixture.Build<GatewaySettings>().With(property => property.StarshipsEndPoint, FakeEndpoint).Create();
            var starshipGateway = new StarshipGateway(httpClient, gatewaySettings);

            var result = await starshipGateway.GetAsync();

            //Assert
            result.Should().NotBeNull();
        }
    }
}
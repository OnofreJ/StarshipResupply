namespace StarshipResupply.Data.Gateway.Tests.Starship
{
    using AutoFixture;
    using FluentAssertions;
    using StarshipResupply.Data.Gateway.Settings;
    using StarshipResupply.Data.Gateway.Starship;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class HttpMessageHandlerFake : HttpMessageHandler
    {
        private readonly string FakeJson = new StreamReader($"{AppContext.BaseDirectory}/Starship/Starship.json").ReadToEnd();

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
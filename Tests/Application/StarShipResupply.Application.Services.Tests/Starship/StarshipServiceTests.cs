namespace StarshipResupply.Application.Services.Tests.Starship
{
    using AutoFixture;
    using FluentAssertions;
    using NSubstitute;
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Application.Services.Starship;
    using StarshipResupply.Data.Gateway.Starship;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class StarshipServiceTests
    {
        private readonly Fixture fixture;
        private readonly IStarshipGateway starshipGateway;
        private readonly StarshipService starshipService;

        public StarshipServiceTests()
        {
            fixture = new Fixture();
            starshipGateway = Substitute.For<IStarshipGateway>();
            starshipService = new StarshipService(starshipGateway);
        }

        [Fact]
        public async Task GetAsync_CallsGateway_ReturnValue()
        {
            //Arrange
            starshipGateway.GetAsync().Returns(fixture.CreateMany<Starship>());

            //Act
            var starships = await starshipService.GetAsync().ConfigureAwait(false);

            //Assert
            starships.Should().NotBeEmpty();
            await starshipGateway.Received(1).GetAsync().ConfigureAwait(false);
        }
    }
}
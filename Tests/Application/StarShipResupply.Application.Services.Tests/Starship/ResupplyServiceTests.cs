namespace StarshipResupply.Application.Services.Tests.Starship
{
    using AutoFixture;
    using FluentAssertions;
    using NSubstitute;
    using StarshipResupply.Application.Services.Starship;
    using StarshipResupply.Domain.Model.Starship;
    using StarshipResupply.Domain.Services.Resupply;
    using Xunit;

    public sealed class ResupplyServiceTests
    {
        private readonly Fixture fixture;
        private readonly IResupplyCalculatorService resupplyCalculatorService;
        private readonly ResupplyService resupplyService;

        public ResupplyServiceTests()
        {
            fixture = new Fixture();
            resupplyCalculatorService = Substitute.For<IResupplyCalculatorService>();
            resupplyService = new ResupplyService(resupplyCalculatorService);
        }

        [Fact]
        public void Calculate_CallsService_ReturnValue()
        {
            //Arrange
            var resultService = fixture.Create<string>();
            var megalights = fixture.Create<decimal>();
            var starship = fixture.Create<StarshipResupply.Application.Dto.Starship.Starship>();

            resupplyCalculatorService.Calculate(Arg.Any<decimal>(), Arg.Any<Starship>()).Returns(resultService);

            //Act
            var result = resupplyService.Calculate(megalights, starship);

            //Assert
            result.Should().Be(resultService);
            resupplyCalculatorService.Received(1).Calculate(Arg.Any<decimal>(), Arg.Any<Starship>());
        }
    }
}
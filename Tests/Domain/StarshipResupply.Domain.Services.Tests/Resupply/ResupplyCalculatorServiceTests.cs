namespace StarshipResupply.Domain.Services.Tests.Resupply
{
    using AutoFixture;
    using FluentAssertions;
    using StarshipResupply.Domain.Model.Starship;
    using StarshipResupply.Domain.Services.Resupply;
    using Xunit;

    public sealed class ResupplyCalculatorServiceTests
    {
        private readonly Fixture fixture;
        private readonly IResupplyCalculatorService resupplyCalculatorService;

        public ResupplyCalculatorServiceTests()
        {
            fixture = new Fixture();
            resupplyCalculatorService = new ResupplyCalculatorService();
        }

        [Fact]
        public void Calculate_InvalidStarshipConsumables_ReturnUnknown()
        {
            //Arrange
            var userInput = 1000000;
            var starship = fixture.Build<Starship>()
                .With(property => property.Mglt, fixture.Create<int>().ToString())
                .Create();

            //Act
            var result = resupplyCalculatorService.Calculate(userInput, starship);

            //Assert
            result.Should().NotBeNull();
            result.Should().Be(ResupplyConstants.Unknown);
        }

        [Fact]
        public void Calculate_InvalidStarshipMegalight_ReturnUnknown()
        {
            //Arrange
            var consumables = "1 week";
            var userInput = 1000000;
            var starship = fixture.Build<Starship>()
                .With(property => property.Consumables, consumables)
                .With(property => property.Mglt, ResupplyConstants.Unknown)
                .Create();

            //Act
            var result = resupplyCalculatorService.Calculate(userInput, starship);

            //Assert
            result.Should().NotBeNull();
            result.Should().Be(ResupplyConstants.Unknown);
        }

        [Fact]
        public void Calculate_ValidInput_ReturnValue()
        {
            //Arrange
            var expectedResult = "74";
            var consumables = "1 week";
            var userInput = 1000000;
            var mglt = "80";
            var starship = fixture.Build<Starship>()
                .With(property => property.Consumables, consumables)
                .With(property => property.Mglt, mglt)
                .Create();

            //Act
            var result = resupplyCalculatorService.Calculate(userInput, starship);

            //Assert
            result.Should().NotBeNull();
            result.Should().Be(expectedResult);
        }
    }
}
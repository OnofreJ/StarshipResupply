namespace StarshipResupply.Domain.Services.Resupply
{
    using StarshipResupply.Domain.Model.Starship;

    public interface IResupplyCalculatorService
    {
        string Calculate(decimal megalights, Starship starship);
    }
}
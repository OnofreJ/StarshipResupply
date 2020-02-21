namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;

    public interface IResupplyService
    {
        string Calculate(decimal megalights, Starship starship);
    }
}
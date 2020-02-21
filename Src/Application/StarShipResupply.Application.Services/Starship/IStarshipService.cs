namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStarshipService
    {
        Task<IEnumerable<Starship>> GetAsync();
    }
}
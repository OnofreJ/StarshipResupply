namespace StarshipResupply.Data.Gateway.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStarshipGateway
    {
        Task<IEnumerable<Starship>> GetAsync();
    }
}
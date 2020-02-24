namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the interface that interacts with the gateway and manipulate the starships.
    /// </summary>
    public interface IStarshipService
    {
        /// <summary>
        /// Method declaration to get the starships.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Starship}"/> object.</returns>
        Task<IEnumerable<Starship>> GetAsync();
    }
}
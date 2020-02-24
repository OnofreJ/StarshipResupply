namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Data.Gateway.Starship;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// This class represents the service that interacts with the gateway and manipulate the starships.
    /// </summary>
    /// <seealso cref="IStarshipService"/>
    internal sealed class StarshipService : IStarshipService
    {
        private readonly IStarshipGateway starshipGateway;

        /// <summary>
        /// Initializes a new instance of the <see cref="StarshipService"/> class.
        /// </summary>
        /// <param name="starshipGateway">The starship gateway.</param>
        public StarshipService(IStarshipGateway starshipGateway)
        {
            this.starshipGateway = starshipGateway;
        }

        /// <summary>
        /// Gets the starships.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Starship}"/> object.</returns>
        public async Task<IEnumerable<Starship>> GetAsync()
        {
            return await starshipGateway.GetAsync().ConfigureAwait(false);
        }
    }
}
namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Data.Gateway.Starship;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    /// <seealso cref="StarshipResupply.Application.Services.Starship.IStarshipService"/>
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
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Starship>> GetAsync()
        {
            return await starshipGateway.GetAsync().ConfigureAwait(false);
        }
    }
}
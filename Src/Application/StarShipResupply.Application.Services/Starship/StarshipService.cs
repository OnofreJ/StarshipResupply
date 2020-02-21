namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Data.Gateway.Starship;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal sealed class StarshipService : IStarshipService
    {
        private readonly IStarshipGateway starshipGateway;

        public StarshipService(IStarshipGateway starshipGateway)
        {
            this.starshipGateway = starshipGateway;
        }

        public async Task<IEnumerable<Starship>> GetAsync()
        {
            return await starshipGateway.GetAsync().ConfigureAwait(false);
        }
    }
}
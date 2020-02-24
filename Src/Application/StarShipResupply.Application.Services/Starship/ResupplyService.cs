namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Domain.Services.Resupply;

    /// <summary>
    /// This class represents the service that calculates resupply.
    /// </summary>
    /// <seealso cref="StarshipResupply.Application.Services.Starship.IResupplyService"/>
    internal sealed class ResupplyService : IResupplyService
    {
        private readonly IResupplyCalculatorService resupplyCalculatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResupplyService"/> class.
        /// </summary>
        /// <param name="resupplyCalculatorService">The resupply calculator service.</param>
        public ResupplyService(IResupplyCalculatorService resupplyCalculatorService)
        {
            this.resupplyCalculatorService = resupplyCalculatorService;
        }

        /// <summary>
        /// Calculates the specified megalights.
        /// </summary>
        /// <param name="megalights">The megalights.</param>
        /// <param name="starship">The starship.</param>
        /// <returns>A <see cref="string"/> object.</returns>
        public string Calculate(decimal megalights, Starship starship)
        {
            return resupplyCalculatorService.Calculate(megalights, new Domain.Model.Starship.Starship
            {
                Consumables = starship.Consumables,
                Mglt = starship.Mglt
            });
        }
    }
}
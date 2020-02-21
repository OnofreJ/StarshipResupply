namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Domain.Services.Resupply;

    internal sealed class ResupplyService : IResupplyService
    {
        private readonly IResupplyCalculatorService resupplyCalculatorService;

        public ResupplyService(IResupplyCalculatorService resupplyCalculatorService)
        {
            this.resupplyCalculatorService = resupplyCalculatorService;
        }

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
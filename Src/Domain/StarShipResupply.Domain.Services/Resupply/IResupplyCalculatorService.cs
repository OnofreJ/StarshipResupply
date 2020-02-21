namespace StarshipResupply.Domain.Services.Resupply
{
    using StarshipResupply.Domain.Model.Starship;

    /// <summary>
    /// Represents the interface with the method declaration for the resupply calculator service.
    /// </summary>
    public interface IResupplyCalculatorService
    {
        /// <summary>
        /// Represents the method definition to calculate the specified megalights.
        /// </summary>
        /// <param name="megalights">The megalights.</param>
        /// <param name="starship">The starship.</param>
        /// <returns>An <see cref="int"/> value.</returns>
        string Calculate(decimal megalights, Starship starship);
    }
}
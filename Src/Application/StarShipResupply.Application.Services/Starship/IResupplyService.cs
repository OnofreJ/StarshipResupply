namespace StarshipResupply.Application.Services.Starship
{
    using StarshipResupply.Application.Dto.Starship;

    /// <summary>
    /// Represents the interface with the method declaration for the resupply calculator service.
    /// </summary>
    public interface IResupplyService
    {
        /// <summary>
        /// Calculates the specified megalights.
        /// </summary>
        /// <param name="megalights">The megalights.</param>
        /// <param name="starship">The starship.</param>
        /// <returns>A <see cref="string"/> object.</returns>
        string Calculate(decimal megalights, Starship starship);
    }
}
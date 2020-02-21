namespace StarshipResupply.Domain.Model.Starship
{
    /// <summary>
    /// Represents the starship.
    /// </summary>
    public class Starship
    {
        /// <summary>
        /// Gets or sets the consumables of starship (in days).
        /// </summary>
        /// <value>The consumables.</value>
        public string Consumables { get; set; }

        /// <summary>
        /// Gets or sets the megalight per hour (abbreviated MGLT).
        /// </summary>
        /// <value>The MGLT.</value>
        public string Mglt { get; set; }
    }
}
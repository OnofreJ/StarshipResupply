namespace StarshipResupply.Application.Dto.Starship
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the starship result.
    /// </summary>
    public class StarshipResult
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the next.
        /// </summary>
        /// <value>The next.</value>
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        public string Previous { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>The results.</value>
        public List<Starship> Results { get; set; }
    }
}
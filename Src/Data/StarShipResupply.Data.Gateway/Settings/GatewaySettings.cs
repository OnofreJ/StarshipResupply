namespace StarshipResupply.Data.Gateway.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GatewaySettings
    {
        /// <summary>
        /// Gets or sets the starships endpoint.
        /// </summary>
        /// <value>The starships endpoint.</value>
        public string StarshipsEndPoint { get; set; }
    }
}
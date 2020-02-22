namespace StarshipResupply.Data.Gateway.Starship
{
    using StarshipResupply.Application.Dto.Starship;
    using StarshipResupply.Data.Gateway.Settings;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    internal sealed class StarshipGateway : IStarshipGateway
    {
        private readonly GatewaySettings gatewaySettings;
        private readonly HttpClient httpClient;

        public StarshipGateway(HttpClient httpClient, GatewaySettings gatewaySettings)
        {
            this.httpClient = httpClient;
            this.gatewaySettings = gatewaySettings;
        }

        public async Task<IEnumerable<Starship>> GetAsync()
        {
            var starships = new List<Starship>();
            var starshipsEndPoint = gatewaySettings.StarshipsEndPoint;

            while (!string.IsNullOrWhiteSpace(starshipsEndPoint))
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseString = await httpClient.GetStringAsync(starshipsEndPoint).ConfigureAwait(false);
                var starshipResult = JsonSerializer.Deserialize<StarshipResult>(responseString, options);

                starshipsEndPoint = starshipResult.Next;

                starships.AddRange(starshipResult.Results);
            }

            return starships;
        }
    }
}
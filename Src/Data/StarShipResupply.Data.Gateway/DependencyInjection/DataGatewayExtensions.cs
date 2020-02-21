namespace StarshipResupply.Data.Gateway.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StarshipResupply.Data.Gateway.Settings;
    using StarshipResupply.Data.Gateway.Starship;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DataGatewayExtensions
    {
        public static IServiceCollection AddGateways(this IServiceCollection services, Action<GatewaySettings> configureSettings)
        {
            services.AddSingleton(serviceProvider =>
            {
                var gatewaySettings = new GatewaySettings();

                configureSettings(gatewaySettings);

                return gatewaySettings;
            });

            services.AddHttpClient<IStarshipGateway, StarshipGateway>();

            return services;
        }
    }
}
namespace StarshipResupply.Application.Services.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StarshipResupply.Application.Services.Starship;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the extensions to application services.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationServicesExtensions
    {
        /// <summary>
        /// Adds the application services to DI container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>An <see cref="IServiceCollection"/> object.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IStarshipService, StarshipService>();
            services.AddSingleton<IResupplyService, ResupplyService>();

            return services;
        }
    }
}
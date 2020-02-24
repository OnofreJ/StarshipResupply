namespace StarshipResupply.Domain.Services.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StarshipResupply.Domain.Services.Resupply;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the extensions to domain services.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DomainServicesExtensions
    {
        /// <summary>
        /// Adds the domain services to DI container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>An <see cref="IServiceCollection"/> object.</returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IResupplyCalculatorService, ResupplyCalculatorService>();

            return services;
        }
    }
}
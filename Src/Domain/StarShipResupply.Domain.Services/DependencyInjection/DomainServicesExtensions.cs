namespace StarshipResupply.Domain.Services.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StarshipResupply.Domain.Services.Resupply;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DomainServicesExtensions
    {
        /// <summary>
        /// Adds the domain services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IResupplyCalculatorService, ResupplyCalculatorService>();

            return services;
        }
    }
}
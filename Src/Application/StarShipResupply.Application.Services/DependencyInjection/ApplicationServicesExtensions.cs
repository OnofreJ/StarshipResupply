namespace StarshipResupply.Application.Services.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StarshipResupply.Application.Services.Starship;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IStarshipService, StarshipService>();
            services.AddSingleton<IResupplyService, ResupplyService>();

            return services;
        }
    }
}
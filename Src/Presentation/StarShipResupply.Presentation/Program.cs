namespace StarshipResupply.Presentation
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using StarshipResupply.Application.Services.DependencyInjection;
    using StarshipResupply.Application.Services.Starship;
    using StarshipResupply.Data.Gateway.DependencyInjection;
    using StarshipResupply.Domain.Services.DependencyInjection;
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the entry point class of the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider ConfigureApplication()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return new ServiceCollection()
                .AddApplicationServices()
                .AddDomainServices()
                .AddGateways(settings => configuration.Bind("GatewaySettings", settings))
                .BuildServiceProvider();
        }

        /// <summary>
        /// Defines the entry point method of the application.
        /// </summary>
        private static void Main()
        {
            var serviceProvider = ConfigureApplication();

            StartApplication(serviceProvider);
        }

        /// <summary>
        /// Prints the welcome message.
        /// </summary>
        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("* Welcome to STAR WARS STARSHIPS RESUPPLY system! *");
            Console.WriteLine("***************************************************");
            Console.WriteLine("Please, input a distance in mega lights (MGLT) to discover");
            Console.WriteLine("how many stops for resupply are required to cover a given distance.");
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        private static void StartApplication(IServiceProvider serviceProvider)
        {
            var exit = false;
            var errorMessage = string.Empty;

            while (!exit)
            {
                try
                {
                    PrintWelcomeMessage();

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        Console.WriteLine(errorMessage);
                    }

                    Console.Write("Enter your distance: ");

                    var megalights = Convert.ToDecimal(Console.ReadLine());
                    var starshipService = serviceProvider.GetService<IStarshipService>();
                    var resupplyService = serviceProvider.GetService<IResupplyService>();
                    var starships = starshipService.GetAsync().Result;

                    Console.WriteLine(string.Empty);

                    foreach (var starship in starships)
                    {
                        var numberOfStops = resupplyService.Calculate(megalights, starship);

                        Console.WriteLine($"{ starship.Name }: {numberOfStops}");
                    }

                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Exit? (Y/N)");

                    exit = Console.ReadLine().ToUpper().Trim() == "Y";
                    errorMessage = string.Empty;

                    Console.Clear();
                }
                catch (Exception exception)
                {
                    errorMessage = $"Oops! Something went wrong - {exception.Message}";
                    Console.Clear();
                }
            }

            Console.WriteLine("Thank you!");
        }
    }
}
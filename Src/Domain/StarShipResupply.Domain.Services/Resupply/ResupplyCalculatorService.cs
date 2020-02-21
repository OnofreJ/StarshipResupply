namespace StarshipResupply.Domain.Services.Resupply
{
    using StarshipResupply.Domain.Model.Starship;
    using System;

    /// <summary>
    /// many stops for resupply are required.
    /// </summary>
    internal sealed class ResupplyCalculatorService : IResupplyCalculatorService
    {
        private const string Day = "day";
        private const string Month = "month";
        private const string UnknownMegalights = "Unknown";
        private const int Unkwnow = 0;
        private const string Week = "week";
        private const string Year = "year";

        public string Calculate(decimal megalights, Starship starship)
        {
            var starshipMegalights = GetStarshipMegalights(starship.Mglt);
            var hours = ConvertConsumablesInHours(starship.Consumables);

            if (starshipMegalights <= 0)
            {
                return UnknownMegalights;
            }

            var numberOfStops = Math.Round(hours * starshipMegalights / megalights);

            return numberOfStops.ToString();
        }

        private int ConvertConsumablesInHours(string consumables)
        {
            var consumableValues = consumables.Split();

            if (consumableValues.Length <= 1)
            {
                return Unkwnow;
            }

            var numberOfDays = GetNumberOfDays(consumableValues[1].ToLower());

            int.TryParse(consumableValues[0], out int number);

            return number * numberOfDays;
        }

        private int GetNumberOfDays(string period)
        {
            if (period.Contains(Day))
            {
                return 24;
            }
            else if (period.Contains(Week))
            {
                return 168;
            }
            else if (period.Contains(Month))
            {
                return 720;
            }
            else if (period.Contains(Year))
            {
                return 8760;
            }
            else
            {
                return 0;
            }
        }

        private int GetStarshipMegalights(string mglt)
        {
            int.TryParse(mglt, out int result);

            return result;
        }
    }
}
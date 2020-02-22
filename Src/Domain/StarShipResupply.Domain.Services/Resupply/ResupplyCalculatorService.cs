namespace StarshipResupply.Domain.Services.Resupply
{
    using StarshipResupply.Domain.Model.Starship;
    using System;
    using System.Linq;

    /// <summary>
    /// This class represents the service that calculates how many stops for resupply are required.
    /// </summary>
    public class ResupplyCalculatorService : IResupplyCalculatorService
    {
        private const string Day = "day";
        private const string Month = "month";
        private const string Unknown = "Unknown";
        private const string Week = "week";
        private const string Year = "year";

        /// <summary>
        /// Calculates the specified megalights.
        /// </summary>
        /// <param name="megalights">The megalights.</param>
        /// <param name="starship">The starship.</param>
        /// <returns>An <see cref="int"/> value.</returns>
        public string Calculate(decimal megalights, Starship starship)
        {
            var starshipMegalights = GetStarshipMegalights(starship.Mglt);
            var hours = ConvertConsumablesInHours(starship.Consumables);

            if (starshipMegalights == default)
            {
                return Unknown;
            }

            var numberOfStops = Math.Truncate(megalights / (hours * starshipMegalights));

            return numberOfStops.ToString();
        }

        /// <summary>
        /// Converts the consumables in hours.
        /// </summary>
        /// <param name="consumables">The consumables.</param>
        /// <returns>An <see cref="int"/> value.</returns>
        private int ConvertConsumablesInHours(string consumables)
        {
            var consumableValues = consumables.Split();

            if (consumableValues.First().Equals(consumableValues.Last()))
            {
                return (int)Hours.Unkwnow;
            }

            var numberOfHours = GetNumberOfHours(consumableValues.Last().ToLower());

            int.TryParse(consumableValues.First(), out int number);

            return number * numberOfHours;
        }

        /// <summary>
        /// Gets the number of hours within a period.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <returns>An <see cref="int"/> value.</returns>
        private int GetNumberOfHours(string period)
        {
            if (period.Contains(Day))
            {
                return (int)Hours.InDay;
            }
            else if (period.Contains(Week))
            {
                return (int)Hours.InWeek;
            }
            else if (period.Contains(Month))
            {
                return (int)Hours.InMonth;
            }
            else if (period.Contains(Year))
            {
                return (int)Hours.InYear;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the starship megalights.
        /// </summary>
        /// <param name="mglt">The megalights.</param>
        /// <returns>An <see cref="int"/> value.</returns>
        private int GetStarshipMegalights(string mglt)
        {
            int.TryParse(mglt, out int result);

            return result;
        }
    }
}
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
        private const int HoursInDay = 24;
        private const int HoursInMonth = 720;
        private const int HoursInWeek = 168;
        private const int HoursInYear = 8760;
        private const string Month = "month";
        private const string UnknownMegalights = "Unknown";
        private const int Unkwnow = 0;
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
                return UnknownMegalights;
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
                return Unkwnow;
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
                return HoursInDay;
            }
            else if (period.Contains(Week))
            {
                return HoursInWeek;
            }
            else if (period.Contains(Month))
            {
                return HoursInMonth;
            }
            else if (period.Contains(Year))
            {
                return HoursInYear;
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
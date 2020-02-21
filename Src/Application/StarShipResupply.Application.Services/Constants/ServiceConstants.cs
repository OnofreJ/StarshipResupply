namespace StarshipResupply.Application.Services.Constants
{
    using System.Collections.Generic;

    public static class ServiceConstants
    {
        private static readonly string East = "EAST";

        private static readonly string North = "NORTH";

        private static readonly string South = "SOUTH";

        private static readonly string West = "WEST";

        public static Dictionary<string, string> ReducibleDirections { get; } = new Dictionary<string, string> {
            { North, South },
            { South, North },
            { East, West },
            { West, East }
        };
    }
}
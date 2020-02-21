namespace StarshipResupply.Infrastructure.CrossCutting
{
    using System;
    using System.Collections.Generic;

    internal static class Guard
    {
        public static T ArgumentNotNull<T>(T value, string argumentName)
        {
            if (EqualityComparer<T>.Default.Equals(value, default))
            {
                throw new ArgumentNullException(argumentName, $"The argument { argumentName } cannot be null.");
            }

            return value;
        }

        public static string ArgumentNotNullOrWhiteSpace(string value, string argumentName)
        {
            ArgumentNotNull(value, argumentName);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"The argument { argumentName } cannot be null, empty or white - space.", argumentName);
            }

            return value;
        }
    }
}
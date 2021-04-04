using System;

namespace CommonLanguageExtensions
{
    /// <summary>
    /// Generic language extensions
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Determine if T is between lower and upper
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="sender">Value to determine if between lower and upper</param>
        /// <param name="minimumValue">Lower of range</param>
        /// <param name="maximumValue">Upper of range</param>
        /// <returns>True if in range, false if not in range</returns>
        /// <example>
        /// <code lang="csharp">
        /// var startDate = new DateTime(2018, 12, 2, 1, 12, 0);
        /// var endDate = new DateTime(2018, 12, 15, 1, 12, 0);
        /// var theDate = new DateTime(2018, 12, 13, 1, 12, 0);
        /// Assert.IsTrue(theDate.Between(startDate,endDate));
        /// </code>
        /// </example>
        public static bool Between<T>(this IComparable<T> sender, T minimumValue, T maximumValue) => sender.CompareTo(minimumValue) >= 0 && sender.CompareTo(maximumValue) <= 0;
        /// <summary>Determines if a value is between two values, exclusive.</summary>
        /// <param name="sender">The source value.</param>
        /// <param name="minimumValue">The minimum value.</param>
        /// <param name="maximumValue">The Maximum value.</param>
        /// <returns><see langword="true"/> if the value is between the two values, exclusive.</returns>
        public static bool BetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue) => sender.CompareTo(minimumValue) > 0 && sender.CompareTo(maximumValue) < 0;
        /// <summary>
        /// Determine if value is positive
        /// </summary>
        /// <typeparam name="T">Type implementing IComparable</typeparam>
        /// <param name="value">Value to test</param>
        /// <returns>true if positive, false otherwise</returns>
        public static bool IsPositive<T>(this T value) where T : struct, IComparable<T> => value.CompareTo(default(T)) > 0;
        /// <summary>
        /// Determine if value is negative
        /// </summary>
        /// <typeparam name="T">Type implementing IComparable</typeparam>
        /// <param name="value">Value to test</param>
        /// <returns>true if negative, false otherwise</returns>
        public static bool IsNegative<T>(this T value) where T : struct, IComparable<T> => value.CompareTo(default(T)) == -1;
    }
}
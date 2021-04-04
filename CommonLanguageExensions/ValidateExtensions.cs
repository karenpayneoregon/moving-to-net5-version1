using System.Text.RegularExpressions;

namespace CommonLanguageExtensions
{
    /// <summary>
    /// Validation extensions
    /// </summary>
    public static class ValidateExtensions
    {
        /// <summary>
        /// Validate
        ///   Don't allow "219-09-999" or "078-05-1120" explicitly
        ///   Don't allow the SSN to begin with 666, 000 or anything between 900-999
        ///   Explicit dash (separating Area and Group numbers)
        ///   Don't allow the Group Number to be "00"
        ///   Another dash (separating Group and Serial numbers)
        ///   Don't allow last four digits to be "0000"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidSsnWithoutDashes(this string value) => Regex.IsMatch(value.CleanSsn(), @"^(?!\b(\d)\1+\b)(?!123456789|219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$");

        /// <summary>
        /// Simple validate 9 digits
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidSsnSimple(this string value)
        {
            var regexItem = new Regex(@"^\d{9}$");
            var matcher = regexItem.Match(value);
            return matcher.Success;
        }
        /// <summary>
        /// Remove hyphens from string
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public static string CleanSsn(this string ssn) => ssn.Replace("-", "");
    }
}

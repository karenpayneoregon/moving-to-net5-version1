namespace CommonLanguageExtensions
{
    /// <summary>
    /// Language extensions for type bool
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// Convert bool to English text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
    }
}

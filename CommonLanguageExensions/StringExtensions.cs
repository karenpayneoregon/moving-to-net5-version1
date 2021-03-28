﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web;

namespace CommonLanguageExensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Split string with space e.g. FirstName becomes First Name
        /// </summary>
        /// <param name="sender">string value with value like FirstName</param>
        /// <returns>Original string if not in proper format or a string with space between variable upper cased tokens</returns>
        public static string SplitCamelCase(this string sender) => Regex.Replace(Regex.Replace(sender, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");

        /// <summary>
        /// Determine if a string can be represented as a numeric.
        /// </summary>
        /// <param name="text">value to determine if can be converted to a string</param>
        /// <returns></returns>
        public static bool IsNumeric(this string text) => double.TryParse(text, out _);

        /// <summary>
        /// Strip alpha characters from a string
        /// </summary>
        /// <param name="text">text to work against</param>
        /// <returns>A string devoid of anything other than numeric values</returns>
        public static string StripperNumbers(this string text) => Regex.Replace(text, "[^A-Za-z]", "");

        public static bool AlphaToInteger(this string text, ref int result)
        {
            var value = Regex.Replace(text, "[^0-9]", "");
            return int.TryParse(value, out result);
        }

        /// <summary>
        /// Determine if string is empty
        /// </summary>
        /// <param name="sender">String to test if null or whitespace</param>
        /// <returns>true if empty or false if not empty</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);

        /// <summary>
        /// Overload of the standard String.Contains method which provides case sensitivity.
        /// </summary>
        /// <param name="sender">String to search</param>
        /// <param name="pSubString">Sub string to match</param>
        /// <param name="pCaseInSensitive">Use case or ignore case</param>
        /// <returns>True if string is in sent string</returns>
        public static bool Contains(this string sender, string pSubString, bool pCaseInSensitive) => pCaseInSensitive ? sender?.IndexOf(pSubString, StringComparison.OrdinalIgnoreCase) >= 0 : sender != null && (bool) sender?.Contains(pSubString);

        /// <summary>
        /// Remove extra spaces in a string
        /// </summary>
        /// <param name="sender">string value</param>
        /// <returns>string with no extra spaces</returns>
        public static string RemoveExtraSpaces(this string sender)
        {
            const RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(sender, " ");
        }

        /// <summary>
        /// Get parameters from a web address
        /// </summary>
        /// <param name="inputString">web address</param>
        /// <param name="key">parameter name</param>
        /// <returns></returns>
        public static List<string> DumpHRefs(this string inputString, string key)
        {
            var resultList = new List<string>();
            const string hRefPattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))";

            try
            {
                var match = Regex.Match(inputString, hRefPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));

                while (match.Success)
                {

                    var myUri = new Uri(match.Groups[1].Value);
                    var articleIdValue = HttpUtility.ParseQueryString(myUri.Query).Get(key);

                    if (!string.IsNullOrWhiteSpace(articleIdValue))
                    {
                        resultList.Add($"{articleIdValue}");
                    }

                    match = match.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return resultList;
            }

            return resultList;
        }
    }
}



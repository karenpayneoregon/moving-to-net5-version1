using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLanguageExtensions
{
    /// <summary>
    /// Date time extensions
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns passed datetime with zero padding using current culture separators
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        /// <remarks>
        /// order of date parts year, month, day which can be changed to say month, day, year
        /// </remarks>
        public static string ZeroPad(this DateTime d)
        {
            string dateSeparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            string timeSeparator = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
            
            var resultShort = $"{d.Year:D2}{dateSeparator}{d.Month:D2}{dateSeparator}{d.Day:D2} {d.Hour:D2}{timeSeparator}{d.Minute:D2}{timeSeparator}{d.Second:D2}";
            var resultLong = d.Year.ToString("D2") + dateSeparator + d.Month.ToString("D2") + dateSeparator + d.Day.ToString("D2") + " " + d.Hour.ToString("D2") + timeSeparator + d.Minute.ToString("D2") + timeSeparator + d.Second.ToString("D2");

            return resultShort;
        }

        /// <summary>
        /// Returns passed datetime with zero padding using user supplied separators
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dateSeparator"></param>
        /// <param name="timeSeparator"></param>
        /// <returns></returns>
        /// <remarks>
        /// order of date parts year, month, day which can be changed to say month, day, year
        /// </remarks>
        public static string ZeroPad(this DateTime d, string dateSeparator, string timeSeparator) => 
            $"{d.Year:D2}{dateSeparator}{d.Month:D2}{dateSeparator}{d.Day:D2} {d.Hour:D2}{timeSeparator}{d.Minute:D2}{timeSeparator}{d.Second:D2}";
    }
}

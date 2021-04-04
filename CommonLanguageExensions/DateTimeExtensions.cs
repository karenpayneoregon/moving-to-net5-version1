using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// <param name="dt"><seealso cref="DateTime"/></param>
        /// <returns></returns>
        /// <remarks>
        /// order of date parts year, month, day which can be changed to say month, day, year
        /// </remarks>
        public static string ZeroPad(this DateTime dt)
        {
            string dateSeparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            string timeSeparator = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
            
            var resultShort = $"{dt.Year:D2}{dateSeparator}{dt.Month:D2}{dateSeparator}{dt.Day:D2} {dt.Hour:D2}{timeSeparator}{dt.Minute:D2}{timeSeparator}{dt.Second:D2}";
            
            /*
            var resultLong = 
                dt.Year.ToString("D2") + 
                dateSeparator + 
                dt.Month.ToString("D2") + 
                dateSeparator + 
                dt.Day.ToString("D2") + " " + 
                dt.Hour.ToString("D2") + 
                timeSeparator + dt.Minute.ToString("D2") + 
                timeSeparator + dt.Second.ToString("D2");
            */
            
            return resultShort;
        }

        /// <summary>
        /// Returns passed datetime with zero padding using user supplied separators
        /// </summary>
        /// <param name="dt"><see cref="DateTime"/></param>
        /// <param name="dateSeparator"></param>
        /// <param name="timeSeparator"></param>
        /// <returns></returns>
        /// <remarks>
        /// order of date parts year, month, day which can be changed to say month, day, year
        /// </remarks>
        public static string ZeroPad(this DateTime dt, string dateSeparator, string timeSeparator) => 
            $"{dt.Year:D2}{dateSeparator}{dt.Month:D2}{dateSeparator}{dt.Day:D2} {dt.Hour:D2}{timeSeparator}{dt.Minute:D2}{timeSeparator}{dt.Second:D2}";

        /// <summary>
        /// Show possible time zone for a DateTimeOffset
        /// </summary>
        /// <param name="offsetTime"><see cref="DateTimeOffset"/></param>
        /// <returns>list of possible time zones</returns>
        /// <remarks>
        /// var dstDate = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
        /// DateTimeOffset thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
        /// Console.WriteLine("{0} could belong to the following time zones:", thisTime.ToString());
        /// thisTime.ShowPossibleTimeZones().ForEach(Console.WriteLine);
        /// </remarks>
        public static List<string> ShowPossibleTimeZones(this DateTimeOffset offsetTime)
        {
            TimeSpan offset = offsetTime.Offset;
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            return (from timeZone in timeZones where timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset) select timeZone.DisplayName).ToList();
        }
    }
}

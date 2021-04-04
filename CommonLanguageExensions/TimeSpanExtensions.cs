using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLanguageExtensions
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Format a TimeSpan with AM PM
        /// </summary>
        /// <param name="sender">TimeSpan to format</param>
        /// <param name="format">Optional format</param>
        /// <returns></returns>
        public static string Formatted(this TimeSpan sender, string format = "hh:mm tt") => DateTime.Today.Add(sender).ToString(format);
    }
}

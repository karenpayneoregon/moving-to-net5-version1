using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonLanguageExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.DateTime;

namespace Tinkering
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var dstDate = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
            
            DateTimeOffset thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
            Console.WriteLine("{0} could belong to the following time zones:", thisTime.ToString());
            thisTime.ShowPossibleTimeZones().ForEach(Console.WriteLine);
        }
    }

   
}

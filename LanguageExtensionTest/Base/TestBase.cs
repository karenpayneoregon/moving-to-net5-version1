using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageExtensionTest.Base
{
    public class TestBase
    {
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set
            {
                TestContextInstance = value;
                TestResults.Add(TestContext);
            }
        }

        public static IList<TestContext> TestResults;
        public List<string> WebAddresses => new()
        {
            "<a href=\"http://web/sub/index.aspx?articleid=9999\">",
            "<a href=\"http://web/sub/index.aspx?articleid=1\">",
            "<a href=\"http://web/sub/index.aspx\">",
            "<a href=\"http://web/sub/index.aspx?articleid=123\">"
        };

    }
}

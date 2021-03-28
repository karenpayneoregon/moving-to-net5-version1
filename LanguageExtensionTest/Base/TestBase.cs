using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageExtensionTest.Base
{
    public class TestBase
    {
        public List<string> WebAddresses => new()
        {
            "<a href=\"http://web/sub/index.aspx?articleid=9999\">",
            "<a href=\"http://web/sub/index.aspx?articleid=1\">",
            "<a href=\"http://web/sub/index.aspx\">",
            "<a href=\"http://web/sub/index.aspx?articleid=123\">"
        };

    }
}

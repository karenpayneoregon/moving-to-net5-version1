using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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
        [TestMethod]
        public void TestMethod2()
        {
            var projectFiles = System.IO.Directory.GetFiles(@"C:\OED\Dotnetland\VS2019\SqlServerNet5Basics", "*.csproj", SearchOption.AllDirectories);

            foreach (var file in projectFiles)
            {
                try
                {
                    var xmlFile = XDocument.Load(file);
                    var propNode = xmlFile.Root.Elements().First();
                    var assemblyName = propNode.Elements().First(x => x.Name.LocalName == "AssemblyName").Value;
                    Console.WriteLine(assemblyName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //propNode.Add(new XElement("DocumentationFile", $"somePlace\\{assemblyName}.XML"));
                //xmlFile.Save(file);
            }
        }
        
    }

   
}

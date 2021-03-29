using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfigurationHelperTest.Base
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
        
        /// <summary>
        /// Copy development appsettings.json file to bin folder
        /// </summary>
        public static void CopyDevelopmentAppSettingsFile()
        {
            
            var baseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            
            if (File.Exists(baseFile))
            {
                File.Delete(baseFile);
            }
            
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"AppSettings", "appsettings_Dev.json"), baseFile);
            
        }
        /// <summary>
        /// Copy development appsettings.json file to bin folder
        /// </summary>
        public static void CopyProductionAppSettingsFile()
        {

            var baseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

            if (File.Exists(baseFile))
            {
                File.Delete(baseFile);
            }

            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings", "appsettings_Prod.json"), baseFile);

        }

        /// <summary>
        /// Test names for production test
        /// </summary>
        public static List<string> DevelopmentTestNames => new()
        {
            "ValidateIsDevelopmentEnvironmentTest",
            "GetDevelopmentConnectionStringTest"
        };
        /// <summary>
        /// Test names for development test
        /// </summary>
        public static List<string> ProductionTestNames => new()
        {
            "ValidateIsProductionEnvironmentTest"
        };
        /// <summary>
        /// Setup for development test
        /// </summary>
        public void DevelopmentSetup()
        {
            if (DevelopmentTestNames.Contains(TestContext.TestName))
            {
                CopyDevelopmentAppSettingsFile();
            }
        }
        /// <summary>
        /// Setup for production test
        /// </summary>
        public void ProductionSetup()
        {
            if (ProductionTestNames.Contains(TestContext.TestName))
            {
                CopyProductionAppSettingsFile();
            }
        }
        /// <summary>
        /// Setup proper appsettings file dependent on test name
        /// </summary>
        public void InitializeTest()
        {
            DevelopmentSetup();
            ProductionSetup();
        }

    }
}

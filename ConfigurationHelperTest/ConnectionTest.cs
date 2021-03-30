using System;
using System.Collections.Generic;
using ConfigurationHelper;
using ConfigurationHelperTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfigurationHelperTest
{
    [TestClass]
    public class ConnectionTest : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            InitializeTest();
        }
        
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }

        /// <summary>
        /// Validate obtaining development connection string
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Connection)]
        public void GetDevelopmentConnectionStringTest()
        {
            var expectedConnectionString = "Server=.\\SQLEXPRESS;Database=NorthWind2020;Integrated Security=true";
            var result = Helper.GetConnectionString();
            Assert.IsTrue(result == expectedConnectionString);
        }
        
        [TestMethod]
        [TestTraits(Trait.Connection)]
        public void ValidateIsDevelopmentEnvironmentTest()
        {
            Assert.IsFalse(Helper.GetEnvironment().Production);
        }
        [TestMethod]
        [TestTraits(Trait.Connection)]
        public void ValidateIsProductionEnvironmentTest()
        {
            Assert.IsTrue(Helper.GetEnvironment().Production);
        }
        [Ignore]
        [TestMethod]
        [TestTraits(Trait.Connection)]
        public void Bad()
        {
            bool flag = false;
            Assert.IsTrue(flag, "expected true");
        }
    }
}

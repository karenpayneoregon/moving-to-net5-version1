using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlClientTest.Base;
using SqlOperations.Classes;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SqlClientTest
{
    [TestClass]
    public class SqlClientTest : TestBase
    {

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }

        /// <summary>
        /// Test getting products for a specific category
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// In this case <see cref="Timeout"/> indicates how long to allow for a connection
        /// to timeout.
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.SqlClientRead)]
        public async Task GetProductsByCategory()
        {
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(TimeOutSeconds));
            }

            var categoryIdentifier = 1;
            var results = await DataOperations.ReadProductsUsingContainerByCategory(_cancellationTokenSource.Token, categoryIdentifier);
            /*
             * Note .All() extension method, there is also .Any() where both accepts a predicate
             *
             * https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all?view=net-5.0
             * https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-5.0
             * https://docs.microsoft.com/en-us/dotnet/api/system.predicate-1?view=net-5.0
             *
             */
            Assert.IsTrue(results.DataTable.AsEnumerable().All(row => row.Field<int>("CategoryId") == categoryIdentifier));
        }
    }
}

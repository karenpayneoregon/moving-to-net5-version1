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
        [TestTraits(Trait.Read)]
        public async Task GetProductsByCategory()
        {
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(TimeOutSeconds));
            }

            var categoryIdentifier = 1;
            var results = await DataOperations.ReadProductsUsingContainerByCategory(_cancellationTokenSource.Token, categoryIdentifier);
            Assert.IsTrue(results.DataTable.AsEnumerable().All(row => row.Field<int>("CategoryId") == categoryIdentifier));

            /*
             * Some might consider these test yet we are only interested in if the DataTable contains only the selected category
             */

            //var expectedProductName = "Chai";
            //var expectedProductIdentifier = 1;
            //var expectedUnitsInStock = 39;
            //var firstProduct = results.DataTable.AsEnumerable().FirstOrDefault(p => p.Field<int>("CategoryId") == categoryIdentifier);
            //Assert.IsTrue(firstProduct is not null, "Expected a product");
            //Assert.IsTrue(firstProduct.Field<string>("ProductName") == expectedProductName, $"Expected product-name {expectedProductName} got {firstProduct.Field<string>("ProductName")}");
            //Assert.IsTrue(firstProduct.Field<int>("ProductId") == expectedProductIdentifier, $"Expected product-id {expectedProductIdentifier} got {firstProduct.Field<int>("ProductId")}");
            //Assert.IsTrue(firstProduct.Field<short>("UnitsInStock") == expectedUnitsInStock, $"Expected units in stock {expectedUnitsInStock} got {firstProduct.Field<short>("UnitsInStock")}");
        }
    }
}

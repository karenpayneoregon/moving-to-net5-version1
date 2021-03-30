using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCoreProductTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlOperationsEntityFrameworkCore;

namespace EntityFrameworkCoreProductTest
{
    [TestClass]
    public class EntityFrameworkProductTest : TestBase
    {

        [TestInitialize]
        public async Task Init()
        {
            if (TestContext.TestName == "UpdateSingleProduct")
            {
                await ResetUpdatedProduct();
            }
        }
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        [ClassCleanup()]
        public static async Task ClassCleanup()
        {
            await ResetUpdatedProduct();
        }

        [TestMethod]
        [TestTraits(Trait.ReadEntityFramework)]
        public async Task GetProductsWithoutProjection()
        {
            var expectedProductName = "Chai";
            var categoryIdentifier = 1;
            var expectedProductIdentifier = 1;
            var expectedUnitsInStock = 39;

            var result = await DataOperations.GetProductsWithoutProjection(categoryIdentifier);
            var firstProduct = result.FirstOrDefault();
            
            Assert.IsTrue(firstProduct is not null, "Expected a product");
            
            Assert.IsTrue(firstProduct.ProductName == expectedProductName,
                $"Expected product-name {expectedProductName} got {firstProduct.ProductName}" );

            Assert.IsTrue(firstProduct.ProductId == expectedProductIdentifier,
                $"Expected product-id {expectedProductIdentifier} got {firstProduct.ProductId}");

            Assert.IsTrue(firstProduct.UnitsInStock == expectedUnitsInStock,
                $"Expected units in stock {expectedUnitsInStock} got {firstProduct.UnitsInStock}");

        }
        /// <summary>
        /// Validate a single product update.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// * Resets are done and explained in comments below
        /// * Having SSMS open to a the following for debugging is good to learn from
        ///   SELECT * FROM NorthWind2020.dbo.Products WHERE dbo.Products.ProductID = 4;
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.UpdateEntityFramework)]
        public async Task UpdateSingleProduct()
        {

            /*
             * Init() ensures the product is in an expected state
             */

            // arrange
            var expectedProductIdentifier = 4;
            var expectedProductName = "Chef Anton's Cajun Seasoning";
            
            // act
            var product = await DataOperations.GetProduct(expectedProductIdentifier);
            
            // assert
            Assert.IsTrue(product.ProductName == expectedProductName);

            // arrange
            product.ProductName = "Chef Anton's Cajun Seasoning Inc";
            
            // act
            var result = await DataOperations.Update(product);
            
            // assert
            Assert.IsTrue(result == 1,"Initial update failed");

            /*
             * ClassCleanup resets the product in SQL-Server
             */
        }


    }
}

using System.Linq;
using System.Threading.Tasks;
using LanguageExtensionTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlOperationsEntityFrameworkCore;

namespace EntityFrameworkCoreProductTest
{
    [TestClass]
    public class EntityFrameworkProductTest : TestBase
    {
        [TestMethod]
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlOperationsEntityFrameworkCore.Models;
using static ValidationLibrary.ValidationHelper;

namespace ValidationWithAnnotationTest
{
    [TestClass]
    public class ProductValidations
    {
        /// <summary>
        /// Validate if giving a product name that violates annotation rules
        /// the errors are triggered
        /// </summary>
        [TestMethod]
        public void ValidateProductsNameRuleFailure()
        {
            // arrange
            var product = new Products() { ProductName = "A" };
            
            // act
            var validationResult = ValidateEntity(product);
            
            // assert
            Assert.IsTrue(validationResult.HasError);
            Assert.IsTrue(validationResult.Errors.Count == 2);

            var expectedErrorMessages = new List<string>() { "ProductName Minimum 3 characters required", "Invalid ProductName" };
            var resultingErrorMessage = validationResult.ErrorMessages;
            
            Assert.IsTrue(expectedErrorMessages.SequenceEqual(resultingErrorMessage),
                "Expected specific error messages from ProductName annotations");


        }
        /// <summary>
        /// Validate ProductName rules are satisfied 
        /// </summary>
        [TestMethod]
        public void ValidateProductsNameRule()
        {
            // arrange
            var product = new Products() { ProductName = "Granny's cookies" };

            // act
            var validationResult = ValidateEntity(product);

            // assert
            Assert.IsFalse(validationResult.HasError);


        }
    }
}

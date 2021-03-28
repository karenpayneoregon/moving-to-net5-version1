using System;
using System.Collections.Generic;
using System.Linq;
using CommonLanguageExensions;
using LanguageExtensionTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageExtensionTest
{
    [TestClass]
    public class StringExtensionsTest : TestBase
    {
        [TestMethod]
        public void IsEmptyOrWhitespace()
        {
            // arrange 
            string value = "";

            // Act-assert
            Assert.IsTrue(value.IsNullOrWhiteSpace());

            // arrange 
            value = "Not empty";

            // Act-assert
            Assert.IsTrue(!value.IsNullOrWhiteSpace());
            
        }
        /// <summary>
        /// Validate extension works by passing in three addresses that have
        /// a parameter we are looking for and one that does not
        /// </summary>
        [TestMethod]
        public void DumpHRefs()
        {
            // arrange
            const string parameter = "articleid";
            var expected = new List<string>() {"9999","1","123" };
            var actual = new List<string>();

            // act
            foreach (var item in WebAddresses)
            {
                if (!item.DumpHRefs(parameter).FirstOrDefault().IsNullOrWhiteSpace())
                {
                    actual.Add(item.DumpHRefs(parameter).FirstOrDefault());
                }
                
            }

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void SplitCamelCase()
        {
            // arrange

            var firstName = "KarenPayne";
            var expected = "Karen Payne";

            var result = firstName.SplitCamelCase();
            
            
            // assert
            Assert.IsTrue(result == expected);

        }

    }
}

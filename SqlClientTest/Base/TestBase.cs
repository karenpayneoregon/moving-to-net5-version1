using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlClientTest.Base
{
    
    /// <summary>
    /// EntityFrameworkProductTest class implements these methods
    /// </summary>
    public class TestBase
    {
        protected const int TimeOutSeconds = 5;
        protected CancellationTokenSource _cancellationTokenSource = new(TimeSpan.FromSeconds(TimeOutSeconds));
        protected static string ConnectionString = "Server=.\\SQLEXPRESS;Database=NorthWind2020;Integrated Security=true";

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
        /// If a runtime exception is invoked in other code there are no guarantees this code will run as intended.
        /// Always have SQL-Server backups just in case of a runtime exception
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ResetUpdatedProduct()
        {
            // created in SSMS
            var updateStatement = @"
            UPDATE [dbo].[Products]
               SET [ProductName] = 'Chef Anton''s Cajun Seasoning'
                  ,[SupplierID] = 2
                  ,[CategoryID] = 2
                  ,[QuantityPerUnit] = '48 - 6 oz jars'
                  ,[UnitPrice] = 22.0000
                  ,[UnitsInStock] = 53
                  ,[UnitsOnOrder] = 0
                  ,[ReorderLevel] = 0
                  ,[Discontinued] = 0
                  ,[DiscontinuedDate] = NULL
             WHERE ProductID = 4";

            try
            {
                await using var cn = new SqlConnection(ConnectionString);
                await using var cmd = new SqlCommand { Connection = cn, CommandText = updateStatement };

                await cn.OpenAsync();

                var affected = await cmd.ExecuteNonQueryAsync();

                return affected == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlServerLibrary.Classes
{
    public class Operations
    {
        public delegate void OnErrorHandler(Exception sender);
        public static event OnErrorHandler ErrorHandler;
        private static string _connectionString =>
            @"Data Source=TODO;Initial Catalog=TODO;Integrated Security=True";

        /// <summary>
        /// Change void to proper return type
        /// </summary>
        public static void Read()
        {

            using var cn = new SqlConnection() { ConnectionString = _connectionString };
            using var cmd = new SqlCommand() { Connection = cn };

            try
            {
                cn.Open();
                
                /*
                 * Write code. . .
                 */
            }
            catch (Exception exception)
            {
                ErrorHandler?.Invoke(exception);
            }

        }
    }
}

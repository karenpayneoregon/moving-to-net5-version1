using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace PopulateDeliveredDateNorthWind2020.Classes
{
    public class Operations
    {
        public delegate void OnErrorHandler(Exception sender);
        public static event OnErrorHandler ErrorHandler;
        private static string _connectionString => ConfigurationHelper.Helper.GetConnectionString();


        /// <summary>
        /// Change void to proper return type
        /// </summary>
        public static DataTable Read()
        {

            using var cn = new SqlConnection() { ConnectionString = _connectionString };
            //using var cmd = new SqlCommand() { Connection = cn, CommandText = "SELECT OrderID, OrderDate, RequiredDate, ShippedDate, DeliveredDate FROM dbo.Orders WHERE DeliveredDate IS NULL;" };
            //using var cmd = new SqlCommand() { Connection = cn, CommandText = "SELECT OrderID, OrderDate, RequiredDate, ShippedDate, DeliveredDate FROM dbo.Orders WHERE DeliveredDate < ShippedDate;" };
            using var cmd = new SqlCommand() { Connection = cn, CommandText = "SELECT        OrderID, OrderDate, RequiredDate, ShippedDate, DeliveredDate  FROM Orders  WHERE (ShippedDate IS NULL)" };
            
            DataTable table = new DataTable();

            try
            {
                cn.Open();
                table.Load(cmd.ExecuteReader());
               
            }
            catch (Exception exception)
            {
                ErrorHandler?.Invoke(exception);
            }

            return table;
        }

        public static void UpDateRow(int id, DateTime date)
        {
            using var cn = new SqlConnection() { ConnectionString = _connectionString };
            using var cmd = new SqlCommand()
            {
                Connection = cn, 
                CommandText = "UPDATE Orders SET DeliveredDate = @DeliverDate WHERE dbo.Orders.OrderID = @Id"
            };

            cmd.Parameters.Add("@DeliverDate", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            cn.Open();

            cmd.ExecuteNonQuery();


        }
    }
}

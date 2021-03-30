using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOperations.Classes
{
    public class Converters
    {
        /// <summary>
        /// Convert a DataRow to a Products instance
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns>A Products, success and on failure an Exception using a named tuple</returns>
        public static (Products, bool, Exception) ToProducts(DataRow row)
        {
            try
            {
                var products = new Products()
                {
                    ProductId = row.Field<int>("ProductId"),
                    ProductName = row.Field<string>("ProductName"),
                    SupplierId = row.Field<int>("SupplierId"),
                    CategoryId = row.Field<int>("CategoryId"),
                    QuantityPerUnit = row.Field<string>("QuantityPerUnit"),
                    UnitPrice = row.Field<decimal>("UnitPrice"),
                    UnitsInStock = row.Field<short>("UnitPrice"),
                    UnitsOnOrder = row.Field<short>("UnitsOnOrder"),
                    ReorderLevel = row.Field<short>("ReorderLevel"),
                    Discontinued = row.Field<bool>("Discontinued"),
                    DiscontinuedDate = row.Field<DateTime>("DiscontinuedDate")
                };

                return (products = new Products(), true, null);
            }
            catch (Exception ex)
            {
                return (new Products(), false, ex);
            }



        }
    }
}

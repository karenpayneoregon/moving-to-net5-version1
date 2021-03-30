using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SqlOperations.Classes
{

    /// <summary>
    /// Class which represents products in NorthWind database.
    /// </summary>
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public override string ToString() => ProductName;

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SqlOperationsEntityFrameworkCore.Models;

namespace SqlOperationsEntityFrameworkCore.Models
{
    /// <summary>
    /// Purpose of this class is to return only data needed rather
    /// than bring in all properties e.g. without using projections
    /// Categories and Supplier properties would be loaded.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// Primary key to supplier
        /// </summary>
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        /// <summary>
        /// Category identifier for product
        /// </summary>
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public override string ToString() => ProductName;

        public static Expression<Func<Products, Product>> Projection =>
            product => new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierName = product.Supplier.CompanyName,
                SupplierId = product.SupplierId,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder, 
                CategoryId = product.CategoryId, 
                CategoryName = product.Category.CategoryName
            };

    }

}

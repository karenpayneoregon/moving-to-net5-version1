using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SqlOperationsEntityFrameworkCore.Configurations;
using SqlOperationsEntityFrameworkCore.Models;

namespace SqlOperationsEntityFrameworkCore
{
    public class DataOperations
    {
        #region TODO

        public delegate void OnConnect(string message);
        public static event OnConnect ConnectMonitor;

        public delegate void OnAfterConnect(string message);
        public static event OnAfterConnect AfterConnectMonitor;

        #endregion

        /// <summary>
        /// Get products by category identifier
        /// </summary>
        /// <param name="categoryIdentifier">Existing category identifier</param>
        /// <returns></returns>
        public static async Task<List<Products>> GetProductsWithoutProjection(int categoryIdentifier)
        {
            var productList = new List<Products>();

            await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();

                productList = await context.Products
                    .Include(product => product.Supplier)
                    .Where(product => product.CategoryId == categoryIdentifier)
                    .ToListAsync();

            });

            return productList;
        }

        /// <summary>
        /// Example for retrieving products via nested projection
        /// </summary>
        /// <returns>Task&lt;List&lt;Product&gt;&gt;</returns>
        public static async Task<List<Product>> GetProductsWithProjection()
        {
            var productList = new List<Product>();

            await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();
                
                productList = await context.Products
                    .Include(product => product.Supplier)
                    .Select(Product.Projection)
                    .ToListAsync();

            });

            return productList;
        }

        /// <summary>
        /// Get all categories suitable for displaying in a ComboBox or
        /// ListBox for reference only but unlike above will have all properties
        /// of Categories table.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Categories>> GetCategoriesAllNoProjectionsAsync()
        {
            var categoryList = new List<Categories>();

            await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();
                
                categoryList = await context.Categories
                    .AsNoTracking()
                    .ToListAsync();

            });

            return categoryList;

        }
    }
}

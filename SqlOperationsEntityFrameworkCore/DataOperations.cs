using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public static async Task<int> Update(Products product)
        {
            
            await using var context = new NorthwindContext();
            context.Entry(product).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public static async Task<Products> GetProduct(int identifier)
        {
            await using var context = new NorthwindContext();
            return context.Products.FirstOrDefault(prod => prod.ProductId == identifier);
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
        /// Return an ordered list of products first by category then by product ASC
        /// </summary>
        /// <returns>Task&lt;List&lt;Product&gt;&gt; ordered by category name then by product name</returns>
        public static async Task<List<Product>> GetProductsWithProjectionOrderByCategory()
        {
            var productList = new List<Product>();

            await Task.Run(async () =>
            {
                
                var products = await GetProductsWithProjection();

                productList = products
                    .OrderBy(p => p.CategoryName)
                    .ThenBy(p => p.ProductName).ToList();



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
        /// <summary>
        /// Simple example for converting Product list to json
        /// </summary>
        /// <param name="productsList"></param>
        /// <param name="fileName"></param>
        public static void ProductsAsJson(List<Product> productsList, string fileName)
        {
            string json = JsonConvert.SerializeObject(productsList, Formatting.Indented);
            File.WriteAllText(fileName,json);
            Console.WriteLine();
        }
        /// <summary>
        /// Remove product from database table by id
        /// </summary>
        /// <param name="productIdentifier">Product identifier</param>
        /// <returns></returns>
        public static bool Remove(int productIdentifier)
        {
            return false;
        }
    }
}

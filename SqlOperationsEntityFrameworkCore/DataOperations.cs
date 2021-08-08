using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SqlOperationsEntityFrameworkCore.Classes;
using SqlOperationsEntityFrameworkCore.Data;
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
        /// <returns>Product list</returns>
        /// <remarks>
        /// Note .TagWith, this will add the information to the results in SQL-Server Profiler output
        /// which can assist a DBA and/or developer to see who wrote and executed the statement and
        /// from what code e.g. in this case the class and method names
        /// </remarks>
        public static async Task<List<Products>> GetProductsWithoutProjection(int categoryIdentifier)
        {
            var productList = new List<Products>();

            await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();

                productList = await context.Products
                    .Include(product => product.Supplier)
                    .Where(product => product.CategoryId == categoryIdentifier)
                    .TagWith($"From: {nameof(DataOperations)}.{nameof(GetProductsWithoutProjection)} by Karen Payne for teaching")
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
        /// Example for working with dates
        /// </summary>
        /// <param name="categoryIdentifier"></param>
        /// <param name="discontinuedDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// Equivalent WHERE statement
        /// WHERE P.DiscontinuedDate IS NOT NULL AND P.CategoryID = 6 AND year(P.DiscontinuedDate) &lt; 2004
        ///
        /// In earlier versions of Entity Framework the following
        ///    prod.DiscontinuedDate.Value.Year
        /// would not be evaluated and cause a runtime exception
        /// </remarks>
        public static async Task<List<Product>> GetProductsNotNullDiscontinuedDate(int categoryIdentifier, int discontinuedDate)
        {
            var productList = new List<Product>();

            await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();

                productList = await context.Products
                    .Include(product => product.Supplier)
                    .Select(Product.Projection).Where(prod =>
                        prod.CategoryId == categoryIdentifier &&
                        prod.DiscontinuedDate.HasValue &&
                        prod.DiscontinuedDate.Value.Year < discontinuedDate)
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

        public static async Task<List<Product>> GetProductsWithProjectionGroupByCategory()
        {
            List<Product> productList = new();

            await Task.Run(async () =>
            {

                List<Product> products = await GetProductsWithProjection();

                productList = products.GroupBy(product => new CategoryProduct
                    {
                        CategoryName = product.CategoryName, 
                        ProductName = product.ProductName
                    })
                    .Select(product => new Product()
                    {
                        ProductId = products.FirstOrDefault().ProductId,
                        CategoryName = product.FirstOrDefault().CategoryName,
                        CategoryId = product.FirstOrDefault().CategoryId,
                        ProductName = product.FirstOrDefault().ProductName,
                        SupplierName = products.FirstOrDefault().SupplierName
                    })
                    .ToList();

            });

            return productList;
        }

        /// <summary>
        /// Get all categories suitable for displaying in a ComboBox or
        /// ListBox for reference only but unlike above will have all properties
        /// of <see cref="Cat"/> table.
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
        /// Simple example for converting <see cref="Product"/> list to json
        /// </summary>
        /// <param name="productsList"></param>
        /// <param name="fileName"></param>
        public static void ProductsAsJson(List<Product> productsList, string fileName)
        {
            string json = JsonConvert.SerializeObject(productsList, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Read products from a physical file and deserialize to a
        /// list of <see cref="Product"/>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Product> ReadProductsFromJsonFile(string fileName)
        {
            List<Product> products = new();

            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return products;
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

        public static List<TModel> ReadFromJson<TModel>(string fileName)
        {
            List<TModel> products = new();

            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                products = JsonConvert.DeserializeObject<List<TModel>>(json);
            }
            return products;
        }
        public static void ModeListToJson<TModel>(List<TModel> list, string fileName)
        {
            var json = JsonConvert.SerializeObject(list, NewtonSettings.SettingsDefault());
            File.WriteAllText(fileName, json);
        }


    }
}

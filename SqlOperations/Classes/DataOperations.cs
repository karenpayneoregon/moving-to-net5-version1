﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BaseExceptionsLibrary;
using ConfigurationHelper;
using DataTableHelpers;
using StopWatchLibrary;

namespace SqlOperations.Classes
{
    public class DataOperations : BaseExceptionProperties
    {
        private static readonly string ConnectionString = Helper.GetConnectionString();
        
        public delegate void OnConnect(string message);
        public static event OnConnect ConnectMonitor;

        public delegate void OnAfterConnect(string message);
        public static event OnAfterConnect AfterConnectMonitor;

        public static void GetConnectionString()
        {
            Debug.WriteLine(Helper.GetConnectionString());
        }

        public static async Task<DataTableResults> ReadProductsUsingContainer(CancellationToken ct)
        {
            
            StopWatcher.Instance.Start();
            
            var result = new DataTableResults() { DataTable = new DataTable() };

            return await Task.Run(async () =>
            {
                await using var cn = new SqlConnection(ConnectionString);
                
                Debug.WriteLine(cn.ConnectionString);
                
                await using var cmd = new SqlCommand {Connection = cn, CommandText = SelectStatement()};
                
                try
                {
                    ConnectMonitor?.Invoke("Before open");
                    await cn.OpenAsync(ct);
                    AfterConnectMonitor?.Invoke($"Elapsed: {StopWatcher.Instance.Elapsed}");
                }
#pragma warning disable 168
                catch (TaskCanceledException tce)
#pragma warning restore 168
                {
                    /*
                     * For debug purposes we have a variable for TaskCanceledException
                     * although we can still see it w/o tce but this is easier for those
                     * not knowledgeable with no var for the exception
                     */
                    
                    result.ConnectionFailed = true;
                    result.ExceptionMessage = "Connection Failed";
                    
                    return result;
                }
                catch (Exception ex)
                {
                    result.GeneralException = ex;
                    return result;
                }

                result.DataTable.Load(await cmd.ExecuteReaderAsync(ct));

                /*
                 * When coding is done properly, these checks are not needed but
                 * there are times when a developer slips so let's perform assertion
                 *
                 * Otherwise (and even better) remove the assertion and allow a run
                 * time exception to be thrown while in development or test mode.
                 *
                 * Note:
                 * First check is a language extension does the same as the other
                 * checks which some may like
                 */

                if (result.DataTable.ColumnExists("ProductID"))
                {
                    result.DataTable.Columns["ProductID"].ColumnMapping = MappingType.Hidden;
                }

                if (result.DataTable.Columns.Contains("SupplierID"))
                {
                    result.DataTable.Columns["SupplierID"].ColumnMapping = MappingType.Hidden;
                }

                if (result.DataTable.Columns.Contains("CategoryID"))
                {
                    result.DataTable.Columns["CategoryID"].ColumnMapping = MappingType.Hidden;
                }



                return result;

            }, ct);

        }
        /// <summary>
        /// Read products into a DataTable with connection timeout where product is in a specific category
        /// </summary>
        /// <param name="ct"><seealso cref="CancellationToken"/></param>
        /// <param name="categoryIdentifier">Existing category identifier</param>
        /// <returns></returns>
        public static async Task<DataTableResults> ReadProductsUsingContainerByCategory(CancellationToken ct, int categoryIdentifier)
        {

            StopWatcher.Instance.Start();

            var result = new DataTableResults() { DataTable = new DataTable() };

            return await Task.Run(async () =>
            {
                await using var cn = new SqlConnection(ConnectionString);
                await using var cmd = new SqlCommand { Connection = cn, CommandText = SelectStatement(categoryIdentifier) };

                try
                {
                    ConnectMonitor?.Invoke("Before open");
                    await cn.OpenAsync(ct);
                    AfterConnectMonitor?.Invoke($"Elapsed: {StopWatcher.Instance.Elapsed}");
                }
#pragma warning disable 168
                catch (TaskCanceledException tce)
#pragma warning restore 168
                {
                    /*
                     * For debug purposes we have a variable for TaskCanceledException
                     * although we can still see it w/o tce but this is easier for those
                     * not knowledgeable with no var for the exception
                     */

                    result.ConnectionFailed = true;
                    result.ExceptionMessage = "Connection Failed";

                    return result;
                }
                catch (Exception ex)
                {
                    result.GeneralException = ex;
                    return result;
                }

                result.DataTable.Load(await cmd.ExecuteReaderAsync(ct));

                return result;

            }, ct);

        }
        /// <summary>
        /// Update a single product
        /// </summary>
        /// <param name="product">Valid product</param>
        /// <returns>success or failure</returns>
        public static async Task<bool> Update(Products product)
        {
            mHasException = false;
            
            await using var cn = new SqlConnection(ConnectionString);
            await using var cmd = new SqlCommand { Connection = cn, CommandText = SelectStatement() };

            try
            {

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@SupplierID", product.SupplierId);
                cmd.Parameters.AddWithValue("@CategoryID", product.CategoryId);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                cmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
                cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
                cmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                cmd.Parameters.AddWithValue("@DiscontinuedDate", product.DiscontinuedDate);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductId);
                
                
                return cmd.ExecuteNonQuery() == 1;
                
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
                
                return false;
                
            }

        }

        public static DataTable DatabaseTableDetails()
        {
            using var cn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand { Connection = cn, CommandText = DatabaseDetailsSelectStatement };
            
            cn.Open();
            var dt = new DataTable();
            
            dt.Load(cmd.ExecuteReader());

            return dt;
        }
        /// <summary>
        /// Example for reading data and returning via a named value tuple
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static async Task<(bool success, DataTable dataTable, Exception exception)> ReadProductsUsingNamedValueTuple(CancellationToken ct)
        {
            
            StopWatcher.Instance.Start();

            DataTable dt = new ();

            return await Task.Run(async () =>
            {
                await using var cn = new SqlConnection(ConnectionString);
                await using var cmd = new SqlCommand { Connection = cn, CommandText = SelectStatement() };

                try
                {
                    ConnectMonitor?.Invoke("Before open");
                    await cn.OpenAsync(ct);
                    AfterConnectMonitor?.Invoke($"Elapsed: {StopWatcher.Instance.Elapsed}");
                    dt.Load(await cmd.ExecuteReaderAsync(ct));

                    /*
                     * See comments in method above on accessing columns
                     */
                    dt.Columns["ProductID"].ColumnMapping = MappingType.Hidden;
                    dt.Columns["SupplierID"].ColumnMapping = MappingType.Hidden;
                    dt.Columns["CategoryID"].ColumnMapping = MappingType.Hidden;
                    
                    return (true, dt, null);

                }
                catch (Exception ex)
                {
                    return  (false, dt, ex);
                }

            }, ct);

        }

        public static async Task<Customers> SingleCustomer(int identifier)
        {
            Customers customer = new ();

            await using var cn = new SqlConnection(ConnectionString);
            await using var cmd = new SqlCommand { Connection = cn, CommandText = SelectStatement() };

            cmd.CommandText =
                "SELECT TOP (1) CustomerIdentifier, CompanyName, ContactId, Street, City, PostalCode, CountryIdentifier " +
                "FROM dbo.Customers " + 
                "WHERE CustomerIdentifier = @CustomerIdentifier";

            cmd.Parameters.Add("@CustomerIdentifier", SqlDbType.Int).Value = identifier;

            await cn.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows) return customer;

            reader.Read();

            customer.CustomerIdentifier = reader.GetInt32(0);
            customer.CompanyName = reader.GetString(1);
            customer.ContactId = reader.GetInt32(2);
            customer.Street = reader.GetString(3);
            customer.City = reader.GetString(4);
            customer.PostalCode = reader.GetString(5);
            customer.CountryIdentifier = reader.GetInt32(6);

            return customer;
        }

        /// <summary>
        /// This SQL was generated in Microsoft SQL-Server Management Studio (it's free)
        /// </summary>
        /// <returns></returns>
        private static string SelectStatement() =>
            @"
SELECT 
    P.ProductID, 
    P.ProductName, 
    P.SupplierID, 
    S.CompanyName, 
    P.CategoryID, 
    C.CategoryName, 
    P.QuantityPerUnit, 
    P.UnitPrice, 
    P.UnitsInStock, 
    P.UnitsOnOrder, 
    P.ReorderLevel, 
    P.Discontinued, 
    P.DiscontinuedDate 
FROM  
    Products AS P 
        INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID 
        INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID";


        private static string SelectStatement(int categoryIdentifier) =>
            @$"
SELECT 
    P.ProductID, 
    P.ProductName, 
    P.SupplierID, 
    S.CompanyName, 
    P.CategoryID, 
    C.CategoryName, 
    P.QuantityPerUnit, 
    P.UnitPrice, 
    P.UnitsInStock, 
    P.UnitsOnOrder, 
    P.ReorderLevel, 
    P.Discontinued, 
    P.DiscontinuedDate 
FROM  
    Products AS P 
        INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID 
        INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID
WHERE P.CategoryID = {categoryIdentifier}";

        private static string DatabaseDetailsSelectStatement =>
            @"
            SELECT	syso.name [Table],
		            sysc.name [Field], 
		            sysc.colorder [FieldOrder], 
		            syst.name [DataType], 
		            sysc.[length] [Length], 
		            sysc.prec [Precision], 
            CASE WHEN sysc.scale IS null THEN '-' ELSE sysc.scale END [Scale], 
            CASE WHEN sysc.isnullable = 1 THEN 'True' ELSE 'False' END [AllowNulls], 
            CASE WHEN sysc.[status] = 128 THEN 'True' ELSE 'False' END [Identity], 
            CASE WHEN sysc.colstat = 1 THEN 'True' ELSE 'False' END [PrimaryKey],
            CASE WHEN fkc.parent_object_id is NULL THEN 'False' ELSE 'True' END [ForeignKey?], 
            CASE WHEN fkc.parent_object_id is null THEN '-' ELSE obj.name  END [RelatedTable],
            CASE WHEN ep.value is NULL THEN '-' ELSE CAST(ep.value as NVARCHAR(500)) END [Description]
            FROM [sys].[sysobjects] AS syso
            JOIN [sys].[syscolumns] AS sysc on syso.id = sysc.id
            LEFT JOIN [sys].[systypes] AS syst ON sysc.xtype = syst.xtype and syst.name != 'sysname'
            LEFT JOIN [sys].[foreign_key_columns] AS fkc on syso.id = fkc.parent_object_id and sysc.colid = fkc.parent_column_id    
            LEFT JOIN [sys].[objects] AS obj ON fkc.referenced_object_id = obj.[object_id]
            LEFT JOIN [sys].[extended_properties] AS ep ON syso.id = ep.major_id and sysc.colid = ep.minor_id and ep.name = 'MS_Description'
            WHERE syso.type = 'U' AND  syso.name != 'sysdiagrams'
            ORDER BY [Table], FieldOrder, Field;
";

        private static string UpdateStatement =>
            @"
            UPDATE dbo.Products
               SET ProductName = @ProductName
                  ,SupplierID = @SupplierID
                  ,CategoryID = @CategoryID
                  ,QuantityPerUnit = @QuantityPerUnit
                  ,UnitPrice = @UnitPrice
                  ,UnitsInStock = @UnitsInStock
                  ,UnitsOnOrder = @UnitsOnOrder
                  ,ReorderLevel = @ReorderLevel
                  ,Discontinued = @Discontinued
                  ,DiscontinuedDate = @DiscontinuedDate
             WHERE ProductID = @ProductID";

        /// <summary>
        /// Used to set column header text in a DataGridView.
        /// The primary key column are abbreviated as are generally not shown
        /// other than for debugging purposes
        /// </summary>
        /// <remarks>
        /// See also
        /// Microsoft TechNet article: DataGridView setup header text using SQL-Server
        /// https://social.technet.microsoft.com/wiki/contents/articles/52160.datagridview-setup-header-text-using-sql-server.aspx
        /// </remarks>
        /// <returns></returns>
        public static Dictionary<string, string> GetDataGridViewColumnText()
        {
            return new() {
                { "ProductID","Id" },
                { "ProductName","Name" },
                { "SupplierID","Supp Id" },
                { "CompanyName","Company" },
                { "CategoryID","Cat Id" },
                { "CategoryName", "Category" },
                { "QuantityPerUnit", "Qty Per Unit" },
                { "UnitPrice", "Price" },
                { "UnitsInStock", "In stock" },
                { "UnitsOnOrder","On order" },
                { "ReorderLevel", "Reorder" },
                { "Discontinued", "Discontinued" },
                { "DiscontinuedDate","Dis date" }
            };
        }
    }
}
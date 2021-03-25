using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCoreExtensions;
using EntityCoreExtensions.Classes;
using SqlOperationsEntityFrameworkCore.Configurations;
using SqlOperationsEntityFrameworkCore.Data.Configurations;

namespace SqlOperationsEntityFrameworkCore
{
    public class HelperOperations
    {
        /// <summary>
        /// List of model names
        /// </summary>
        /// <returns>Model name as a list</returns>
        /// <remarks>
        /// var names = await HelperOperations.ModelNameList();
        /// </remarks>
        public static async Task<List<string>> ModelNameList()
        {
            await using var context = new NorthwindContext();
            return await Task.Run(() => context.Model
                .GetEntityTypes()
                .Select(entityType => entityType.ClrType)
                .Select(type => type.Name)
                .ToList());
        }
        /// <summary>
        /// Hard-coded sample for getting comments for a property. In this case
        /// in <see cref="ProductsConfiguration"/> the following sets the comment for ProductName
        /// 
        /// entity.Property(e => e.ProductName).HasComment("Product name");
        ///
        /// For use in an application add a parameter for class name e.g. Products
        /// and another parameter for property name e.g. ProductName. Then change the return
        /// type to string.
        ///
        /// Another version would return list of <see cref="ModelComment"/> while using a parameter for class name
        /// </summary>
        public static void Comments()
        {
            using var context = new NorthwindContext();
            var comments = context.Comments("Products");

            Debug.WriteLine(comments.FirstOrDefault(product => product.Name == "ProductName").Comment);
            
        }
    }
}

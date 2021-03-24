using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlOperationsEntityFrameworkCore.Configurations;

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
    }
}

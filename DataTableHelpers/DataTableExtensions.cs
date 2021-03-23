using System.Data;

namespace DataTableHelpers
{
    /// <summary>
    /// DataTable extensions 
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Does column name exists in the DataTable
        /// </summary>
        /// <param name="sender">DataTable with columns</param>
        /// <param name="columnName">Column name to check if exists in sender</param>
        /// <returns></returns>
        public static bool ColumnExists(this DataTable sender, string columnName) => sender.Columns.Contains(columnName);
    }
}

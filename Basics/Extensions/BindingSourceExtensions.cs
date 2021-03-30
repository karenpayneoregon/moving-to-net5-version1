using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRead.Extensions
{
    public static class BindingSourceExtensions
    {
        /// <summary>
        /// Convert Current property to a DataRow
        /// </summary>
        /// <param name="sender">BindingSource.Current property</param>
        /// <returns>DataRow if Current is a DataRowView otherwise a runtime exception is thrown</returns>
        /// <remarks>
        /// It's inherently not wise to create an extension method using an object as the target.
        /// When doing so, test the target type with a unit test.
        /// </remarks>
        public static DataRow ToDataRow(this object sender)
        {
            return sender is DataRowView view ? view.Row : throw new ArgumentException("Expected a DataRowView");
        }
    }
}

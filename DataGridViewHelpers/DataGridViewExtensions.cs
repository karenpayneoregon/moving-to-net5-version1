using System;
using System.Windows.Forms;

namespace DataGridViewHelpers
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Expand all columns and suitable for working with
        /// Entity Framework
        /// </summary>
        /// <param name="sender"></param>
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
    }
}

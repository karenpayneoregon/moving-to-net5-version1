﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        public static void ExpandColumns([NotNull] this DataGridView sender)
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

        /// <summary>
        /// Convert column Header text to a delimited string
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string DelimitedHeaders(this DataGridView sender) =>
            string.Join(",", sender.Columns.OfType<DataGridViewColumn>()
                .Select(column => column.HeaderText).ToArray());

        /// <summary>
        /// Create a string array of data in the DataGridView, does not include header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="delimiter">Delimiter which defaults to a comma</param>
        /// <returns>array comprised of rows/cell data without header</returns>
        public static string[] ToDelimited(this DataGridView sender, string delimiter = ",") =>
            (sender.Rows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new {
                    row,
                    rowItem = string.Join(delimiter,
                        Array.ConvertAll(row.Cells.Cast<DataGridViewCell>().ToArray(), c =>
                            ((c.Value == null) ? "" : c.Value.ToString())))
                })
                .Select(@t => @t.rowItem)).ToArray();

        /// <summary>
        ///  Create a string array of data in the DataGridView, includes header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="delimiter">Delimiter which defaults to a comma</param>
        /// <returns>array comprised of rows/cell data with header</returns>
        public static string[] ToDelimitedWithHeaders(this DataGridView sender, string delimiter = ",")
        {
            var headers = sender.DelimitedHeaders();
            var data = sender.ToDelimited().ToList();
            data.Insert(0, headers);
            return data.ToArray();

        }
    }
}

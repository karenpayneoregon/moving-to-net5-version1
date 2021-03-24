#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BasicReadEntityFrameworkCore.LanguageExtensions;
using DataGridViewHelpers;

using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SqlOperationsEntityFrameworkCore;
using SqlOperationsEntityFrameworkCore.Models;

using static WinFormDialogs.Dialogs;

namespace BasicReadEntityFrameworkCore
{
    /// <summary>
    /// Demonstrate
    /// * Reading data
    /// * Change notification in tangent with INotifyPropertyChanged in Product class
    /// * Simple language extensions
    /// * Monitoring changes to the BindingSource via ListChanged event
    /// </summary>
    /// <remarks>
    /// As coded the DataGridView will not sort but by implementing <see cref="SortableBindingList{T}"/>
    /// </remarks>
    public partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            Shown += OnShown;
        }

        private async void OnShown(object? sender, EventArgs e)
        {
            _bindingSource.DataSource = await DataOperations.GetProductsWithProjectionOrderByCategory();
            dataGridView1.DataSource = _bindingSource;
            
            dataGridView1.ExpandColumns();

            ProductNameTextBox.DataBindings.Add("Text", _bindingSource, "ProductName");
            ProductIdentifierTextBox.DataBindings.Add("Text", _bindingSource, "ProductId");
            
            _bindingSource.ListChanged += BindingSourceOnListChanged;
            
            dataGridView1.UserDeletingRow += DataGridView1OnUserDeletingRow;
        }
        
        /// <summary>
        /// User request to remove current DataGridView row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1OnUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = PromptRowRemoval();
        }
        /// <summary>
        /// Delete current product with yes/no prompt
        /// </summary>
        /// <returns>bool which is feed to e.Cancel in OnUserDeletingRow event</returns>
        /// <remarks>
        /// This can be optimized, leaving this as is for teaching
        /// </remarks>
        private bool PromptRowRemoval()
        {
            if (_bindingSource.HasCurrent())
            {

                if (Question($"Remove {_bindingSource.ProductName()}"))
                {
                    if (!DataOperations.Remove(_bindingSource.ProductIdentifier()))
                    {
                        MessageBox.Show($"Failed to remove\n{_bindingSource.ProductName()}");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
                return true;
            }

            return true;
        }

        /// <summary>
        /// Listen for changes to the underlying data 
        /// </summary>
        /// <param name="sender">BindingSource</param>
        /// <param name="e"><see cref="ListChangedEventArgs"/></param>
        private void BindingSourceOnListChanged(object sender, ListChangedEventArgs e)
        {

            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    break;
                case ListChangedType.ItemAdded:
                    break;
                case ListChangedType.ItemDeleted:
                    break;
                case ListChangedType.ItemMoved:
                    break;
                case ListChangedType.ItemChanged:
                    Debug.WriteLine("");
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                    break;
                case ListChangedType.PropertyDescriptorDeleted:
                    break;
                case ListChangedType.PropertyDescriptorChanged:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Get current Product information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is null)
            {
                return;
            }

            var current = ((Product)_bindingSource.Current);
            var productId = current.ProductId;
            var productName = current.ProductName;

            MessageBox.Show($"{productId}\n{productName}");
        }

        private void ExportProductsJsonButton_Click(object sender, EventArgs e)
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Products.json");
            var productList = (List<Product>) _bindingSource.DataSource;
            DataOperations.ProductsAsJson(productList,fileName);
            
        }
    }
}

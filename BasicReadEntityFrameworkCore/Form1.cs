#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewHelpers;
using SqlOperationsEntityFrameworkCore;
using SqlOperationsEntityFrameworkCore.Models;
using static WinFormDialogs.Dialogs;

namespace BasicReadEntityFrameworkCore
{
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
            
            _bindingSource.ListChanged += BindingSourceOnListChanged;
            
            dataGridView1.UserDeletingRow += DataGridView1OnUserDeletingRow;
        }

        private void DataGridView1OnUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = PromptRowRemoval();

        }

        private bool PromptRowRemoval()
        {
            if (_bindingSource.Current is not null)
            {
                var product = (Product) _bindingSource.Current;
                if (Question($"Remove {product.ProductName}"))
                {
                    if (!DataOperations.Remove(product.ProductId))
                    {
                        MessageBox.Show($"Failed to remove\n{product.ProductName}");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return !Question($"Remove {product.ProductName}");
            }

            return true;
        }
        

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
    }
}

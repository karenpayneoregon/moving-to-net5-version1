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
using PopulateDeliveredDateNorthWind2020.Classes;

namespace PopulateDeliveredDateNorthWind2020
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new ();
        public Form1()
        {
            InitializeComponent();

            Shown += OnShown;
        }

        private void OnShown(object? sender, EventArgs e)
        {
            ReloadGrid();
        }

        private void ReloadGrid()
        {
            _bindingSource.DataSource = Operations.Read();
            dataGridView1.DataSource = _bindingSource;

            _bindingSource.PositionChanged += BindingSourceOnPositionChanged;
            RowChanged();
            Text = $"Remaining {_bindingSource.Count}";
        }

        private void BindingSourceOnPositionChanged(object? sender, EventArgs e)
        {
            if (_bindingSource.Current is not null)
            {
                RowChanged();
            }
        }

        private void RowChanged()
        {
            if (_bindingSource.Current is null)
            {
                MessageBox.Show("Nothing to show");
                return;
            }

            listBox1.Items.Clear();
            var row = ((DataRowView)_bindingSource.Current).Row;

            var RequiredDate = row.Field<DateTime>("RequiredDate");
            
            listBox1.Items.Add($"{RequiredDate.AddDays(-30):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-14):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-6):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-5):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-4):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-3):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-2):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(-1):d}");
            listBox1.Items.Add($"{RequiredDate:d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(1):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(2):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(3):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(6):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(10):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(14):d}");
            listBox1.Items.Add($"{RequiredDate.AddDays(24):d}");

            listBox1.SelectedIndex = 8;

            ActiveControl = listBox1;

            Text = $"Remaining {_bindingSource.Count}";

        }

        private void SetCurrentDeliverDateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var row = ((DataRowView)_bindingSource.Current).Row;

                var id = row.Field<int>("OrderId");
                var dateValue = Convert.ToDateTime(listBox1.Text);
                Operations.UpDateRow(id, dateValue);
                _bindingSource.RemoveCurrent();
                RowChanged();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            ReloadGrid();
        }
    }
}

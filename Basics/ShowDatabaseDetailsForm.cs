using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewHelpers;
using SqlOperations.Classes;

namespace BasicRead
{
    public partial class ShowDatabaseDetailsForm : Form
    {
        public ShowDatabaseDetailsForm()
        {
            InitializeComponent();
            
            Shown += OnShown;
        }

        private void OnShown(object? sender, EventArgs e)
        {
            dataGridView1.DataSource = DataOperations.DatabaseTableDetails();
            dataGridView1.ExpandColumns();
        }
    }
}

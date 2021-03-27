using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopulateComboBox.Classes;

namespace PopulateComboBox
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _employeeBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            _employeeBindingSource.DataSource = Operations.ReadEmployees();
            EmployeeComboBox.DataSource = _employeeBindingSource;
        }

        private void CurrentEmployeeButton_Click(object sender, EventArgs e)
        {
            if (_employeeBindingSource.Current == null) return;
            
            var emp = (Employee) _employeeBindingSource.Current;
            MessageBox.Show(
                $"ID: {emp.EmployeeID}\n"+ 
                $"Contact Id: {emp.ContactTypeIdentifier}\nName {emp.FirstName} {emp.LastName}");
        }
    }
}

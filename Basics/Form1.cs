using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using BasicRead.Classes;
using DataGridViewHelpers;
using SqlOperations.Classes;
using WinFormsHelpers;

namespace BasicRead
{
    // See also: https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types/
#nullable enable
    
    public partial class Form1 : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        /// <summary>
        /// How many seconds to wait for a successful or failed connection to open or not
        /// </summary>
        private const int TimeOutSeconds = 5;
        /// <summary>
        /// Pass the time-out for wait period for the connection. For more on time-out see the following
        /// https://social.technet.microsoft.com/wiki/contents/articles/54260.sql-server-freezes-when-connecting-c.aspx
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = new(TimeSpan.FromSeconds(TimeOutSeconds));
        public Form1()
        {
            InitializeComponent();
            Shown += OnShown;

            DataOperations.ConnectMonitor += DataOperationsOnConnectMonitor;
            DataOperations.AfterConnectMonitor += DataOperationsOnAfterConnectMonitor;
        }

        private void DataOperationsOnAfterConnectMonitor(string message)
        {
            listBox1.InvokeIfRequired(lb => { lb.Items.Add(message); });
        }

        private void DataOperationsOnConnectMonitor(string message)
        {
            listBox1.InvokeIfRequired(lb => { lb.Items.Add(message); });
        }

        private async void OnShown(object? sender, EventArgs e)
        {
            await LoadData1(true);
        }

        private async Task LoadData(bool firstTime = false)
        {
            CheckFirstTime(firstTime);

            var dataResults = await DataOperations.ReadProductsUsingContainer(_cancellationTokenSource.Token);

            if (dataResults.HasException)
            {
                MessageBox.Show(dataResults.ConnectionFailed ? 
                    @"Connection failed" : 
                    dataResults.GeneralException.Message);
            }
            else
            {
                _bindingSource.DataSource = dataResults.DataTable;

                dataGridView1.DataSource = _bindingSource;
                ProductNameTextBox.DataBindings.Add("Text", _bindingSource, "ProductName");

            }
        }
        /// <summary>
        /// Determine if the CancellationTokenSource needs to be re-created. Pass true for instance
        /// on the shown event and if later a reload is needed pass false.
        /// </summary>
        /// <param name="firstTime">true if first time creating, false otherwise</param>
        private void CheckFirstTime(bool firstTime)
        {
            if (!firstTime)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(TimeOutSeconds));
                }
            }
        }

        private async Task LoadData1(bool firstTime = false)
        {
            var (success, dataTable, exception) = await DataOperations.ReadProductsUsingNamedValueTuple(_cancellationTokenSource.Token);

            if (success)
            {
                _bindingSource.DataSource = dataTable;

                dataGridView1.DataSource = _bindingSource;

                var columnDict = DataOperations.GetDataGridViewColumnText();
                foreach (DataGridViewColumn dataGridViewColumn in dataGridView1.Columns)
                {
                    Debug.WriteLine(dataGridViewColumn.Name);
                    if (columnDict.ContainsKey(dataGridViewColumn.Name))
                    {
                        dataGridViewColumn.HeaderText = columnDict[dataGridViewColumn.Name];
                    }
                }

                dataGridView1.ExpandColumns();


                ProductNameTextBox.DataBindings.Add("Text", _bindingSource, "ProductName");
            }
            else
            {
                MessageBox.Show(exception is TaskCanceledException ? "Connection failed" : $"Failed to read data\n{exception.Message}");
            }
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is null)
            {
                return;
            }
            
            var current = ((DataRowView) _bindingSource.Current).Row;
            var productId = current.Field<int>("ProductID");
            var productName = current.Field<string>("ProductName");

            MessageBox.Show($"{productId}\n{productName}");
        }
    }
}

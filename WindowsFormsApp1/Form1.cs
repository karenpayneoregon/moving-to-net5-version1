using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly FileOperations _fileOperations = 
            new FileOperations("C:\\OED","C:\\OED\\Target", "*.txt");
        
        public Form1()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _fileOperations.Stop();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _fileOperations.Start();
        }

        private void Example()
        {
            int DigitStartY = 1;
            int DigitEndY = 25;
            for (int i = DigitStartY; i <= DigitEndY; i++)
            {
                char FindCol = (char)(i + 64);
                var ColumnName = FindCol.ToString();
                Debug.WriteLine(ColumnName);
            }
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            //_fileOperations.Stop();

            
        }
    }
}

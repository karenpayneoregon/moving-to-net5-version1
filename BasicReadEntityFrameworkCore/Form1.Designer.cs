
namespace BasicReadEntityFrameworkCore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CurrentButton = new System.Windows.Forms.Button();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityPerUnitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsInStockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsOnOrderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentButton
            // 
            this.CurrentButton.Location = new System.Drawing.Point(12, 369);
            this.CurrentButton.Name = "CurrentButton";
            this.CurrentButton.Size = new System.Drawing.Size(120, 23);
            this.CurrentButton.TabIndex = 10;
            this.CurrentButton.Text = "Current";
            this.CurrentButton.UseVisualStyleBackColor = true;
            this.CurrentButton.Click += new System.EventHandler(this.CurrentButton_Click);
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Location = new System.Drawing.Point(12, 315);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(283, 23);
            this.ProductNameTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product name";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 227);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(213, 49);
            this.listBox1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductNameColumn,
            this.CategoryNameColumn,
            this.QuantityPerUnitColumn,
            this.UnitPriceColumn,
            this.UnitsInStockColumn,
            this.UnitsOnOrderColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 209);
            this.dataGridView1.TabIndex = 6;
            // 
            // ProductNameColumn
            // 
            this.ProductNameColumn.DataPropertyName = "ProductName";
            this.ProductNameColumn.HeaderText = "Name";
            this.ProductNameColumn.Name = "ProductNameColumn";
            // 
            // CategoryNameColumn
            // 
            this.CategoryNameColumn.DataPropertyName = "CategoryName";
            this.CategoryNameColumn.HeaderText = "Category";
            this.CategoryNameColumn.Name = "CategoryNameColumn";
            // 
            // QuantityPerUnitColumn
            // 
            this.QuantityPerUnitColumn.DataPropertyName = "QuantityPerUnit";
            this.QuantityPerUnitColumn.HeaderText = "Qty Per";
            this.QuantityPerUnitColumn.Name = "QuantityPerUnitColumn";
            // 
            // UnitPriceColumn
            // 
            this.UnitPriceColumn.DataPropertyName = "UnitPrice";
            this.UnitPriceColumn.HeaderText = "Unit Price";
            this.UnitPriceColumn.Name = "UnitPriceColumn";
            // 
            // UnitsInStockColumn
            // 
            this.UnitsInStockColumn.DataPropertyName = "UnitsInStock";
            this.UnitsInStockColumn.HeaderText = "In Stock";
            this.UnitsInStockColumn.Name = "UnitsInStockColumn";
            // 
            // UnitsOnOrderColumn
            // 
            this.UnitsOnOrderColumn.DataPropertyName = "UnitsOnOrder";
            this.UnitsOnOrderColumn.HeaderText = "On Order";
            this.UnitsOnOrderColumn.Name = "UnitsOnOrderColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 404);
            this.Controls.Add(this.CurrentButton);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entity Framework version";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CurrentButton;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityPerUnitColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsInStockColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsOnOrderColumn;
    }
}


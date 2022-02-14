
namespace PopulateDeliveredDateNorthWind2020
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SetCurrentDeliverDateButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ReloadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(607, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // SetCurrentDeliverDateButton
            // 
            this.SetCurrentDeliverDateButton.Location = new System.Drawing.Point(645, 50);
            this.SetCurrentDeliverDateButton.Name = "SetCurrentDeliverDateButton";
            this.SetCurrentDeliverDateButton.Size = new System.Drawing.Size(194, 23);
            this.SetCurrentDeliverDateButton.TabIndex = 1;
            this.SetCurrentDeliverDateButton.Text = "Set current deliver date";
            this.SetCurrentDeliverDateButton.UseVisualStyleBackColor = true;
            this.SetCurrentDeliverDateButton.Click += new System.EventHandler(this.SetCurrentDeliverDateButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(645, 79);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(194, 334);
            this.listBox1.TabIndex = 2;
            // 
            // ReloadButton
            // 
            this.ReloadButton.Location = new System.Drawing.Point(645, 12);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(194, 23);
            this.ReloadButton.TabIndex = 3;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 470);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.SetCurrentDeliverDateButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change deliver date";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SetCurrentDeliverDateButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ReloadButton;
    }
}


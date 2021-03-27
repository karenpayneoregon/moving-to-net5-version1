
namespace PopulateComboBox
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.CurrentEmployeeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmployeeComboBox
            // 
            this.EmployeeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmployeeComboBox.FormattingEnabled = true;
            this.EmployeeComboBox.Location = new System.Drawing.Point(38, 25);
            this.EmployeeComboBox.Name = "EmployeeComboBox";
            this.EmployeeComboBox.Size = new System.Drawing.Size(291, 21);
            this.EmployeeComboBox.TabIndex = 0;
            // 
            // CurrentEmployeeButton
            // 
            this.CurrentEmployeeButton.Location = new System.Drawing.Point(335, 23);
            this.CurrentEmployeeButton.Name = "CurrentEmployeeButton";
            this.CurrentEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.CurrentEmployeeButton.TabIndex = 1;
            this.CurrentEmployeeButton.Text = "Current";
            this.CurrentEmployeeButton.UseVisualStyleBackColor = true;
            this.CurrentEmployeeButton.Click += new System.EventHandler(this.CurrentEmployeeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 450);
            this.Controls.Add(this.CurrentEmployeeButton);
            this.Controls.Add(this.EmployeeComboBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComboBox with class";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox EmployeeComboBox;
        private System.Windows.Forms.Button CurrentEmployeeButton;
    }
}


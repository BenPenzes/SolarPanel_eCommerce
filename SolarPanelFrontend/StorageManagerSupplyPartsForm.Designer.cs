namespace SolarPanelFrontend
{
    partial class StorageManagerSupplyPartsForm
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
            this.PartsComboBox = new System.Windows.Forms.ComboBox();
            this.PartCountTextBox = new System.Windows.Forms.TextBox();
            this.SupplyPartsbutton = new System.Windows.Forms.Button();
            this.PartCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PartsComboBox
            // 
            this.PartsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartsComboBox.FormattingEnabled = true;
            this.PartsComboBox.Location = new System.Drawing.Point(69, 37);
            this.PartsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PartsComboBox.Name = "PartsComboBox";
            this.PartsComboBox.Size = new System.Drawing.Size(189, 28);
            this.PartsComboBox.TabIndex = 0;
            // 
            // PartCountTextBox
            // 
            this.PartCountTextBox.Location = new System.Drawing.Point(73, 110);
            this.PartCountTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PartCountTextBox.Name = "PartCountTextBox";
            this.PartCountTextBox.Size = new System.Drawing.Size(182, 27);
            this.PartCountTextBox.TabIndex = 1;
            // 
            // SupplyPartsbutton
            // 
            this.SupplyPartsbutton.Location = new System.Drawing.Point(73, 152);
            this.SupplyPartsbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SupplyPartsbutton.Name = "SupplyPartsbutton";
            this.SupplyPartsbutton.Size = new System.Drawing.Size(183, 46);
            this.SupplyPartsbutton.TabIndex = 2;
            this.SupplyPartsbutton.Text = "Supply Parts";
            this.SupplyPartsbutton.UseVisualStyleBackColor = true;
            this.SupplyPartsbutton.Click += new System.EventHandler(this.SupplyPartsButton_Click);
            // 
            // PartCountLabel
            // 
            this.PartCountLabel.AutoSize = true;
            this.PartCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PartCountLabel.Location = new System.Drawing.Point(111, 78);
            this.PartCountLabel.Name = "PartCountLabel";
            this.PartCountLabel.Size = new System.Drawing.Size(104, 28);
            this.PartCountLabel.TabIndex = 3;
            this.PartCountLabel.Text = "Part Count";
            // 
            // StorageManagerSupplyPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 234);
            this.Controls.Add(this.PartCountLabel);
            this.Controls.Add(this.SupplyPartsbutton);
            this.Controls.Add(this.PartCountTextBox);
            this.Controls.Add(this.PartsComboBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StorageManagerSupplyPartsForm";
            this.Text = "StorageManagerSupplyPartsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox PartsComboBox;
        private TextBox PartCountTextBox;
        private Button SupplyPartsbutton;
        private Label PartCountLabel;
    }
}
namespace SolarPanelFrontend
{
    partial class SpecialistAddOrderEntryToOrderForm
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
            this.PartNamesComboBox = new System.Windows.Forms.ComboBox();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.AddPartButton = new System.Windows.Forms.Button();
            this.InventoryLabel = new System.Windows.Forms.Label();
            this.NumberInStorageLabel = new System.Windows.Forms.Label();
            this.PartsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PartNamesComboBox
            // 
            this.PartNamesComboBox.FormattingEnabled = true;
            this.PartNamesComboBox.Location = new System.Drawing.Point(93, 86);
            this.PartNamesComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PartNamesComboBox.Name = "PartNamesComboBox";
            this.PartNamesComboBox.Size = new System.Drawing.Size(200, 28);
            this.PartNamesComboBox.TabIndex = 0;
            this.PartNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.PartNamesComboBox_SelectedIndexChanged);
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(93, 149);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(48, 20);
            this.CountLabel.TabIndex = 1;
            this.CountLabel.Text = "Count";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(93, 172);
            this.CountTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.Size = new System.Drawing.Size(200, 27);
            this.CountTextBox.TabIndex = 2;
            // 
            // AddPartButton
            // 
            this.AddPartButton.Location = new System.Drawing.Point(160, 207);
            this.AddPartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddPartButton.Name = "AddPartButton";
            this.AddPartButton.Size = new System.Drawing.Size(86, 31);
            this.AddPartButton.TabIndex = 3;
            this.AddPartButton.Text = "Add Part";
            this.AddPartButton.UseVisualStyleBackColor = true;
            this.AddPartButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // InventoryLabel
            // 
            this.InventoryLabel.AutoSize = true;
            this.InventoryLabel.Location = new System.Drawing.Point(252, 118);
            this.InventoryLabel.Name = "InventoryLabel";
            this.InventoryLabel.Size = new System.Drawing.Size(17, 20);
            this.InventoryLabel.TabIndex = 4;
            this.InventoryLabel.Text = "0";
            // 
            // NumberInStorageLabel
            // 
            this.NumberInStorageLabel.AutoSize = true;
            this.NumberInStorageLabel.Location = new System.Drawing.Point(110, 118);
            this.NumberInStorageLabel.Name = "NumberInStorageLabel";
            this.NumberInStorageLabel.Size = new System.Drawing.Size(136, 20);
            this.NumberInStorageLabel.TabIndex = 5;
            this.NumberInStorageLabel.Text = "Number in storage:";
            // 
            // PartsLabel
            // 
            this.PartsLabel.AutoSize = true;
            this.PartsLabel.Location = new System.Drawing.Point(93, 62);
            this.PartsLabel.Name = "PartsLabel";
            this.PartsLabel.Size = new System.Drawing.Size(40, 20);
            this.PartsLabel.TabIndex = 6;
            this.PartsLabel.Text = "Parts";
            // 
            // SpecialistAddOrderEntryToOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 298);
            this.Controls.Add(this.PartsLabel);
            this.Controls.Add(this.NumberInStorageLabel);
            this.Controls.Add(this.InventoryLabel);
            this.Controls.Add(this.AddPartButton);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.PartNamesComboBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SpecialistAddOrderEntryToOrderForm";
            this.Text = "AddPartToOrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox PartNamesComboBox;
        private Label CountLabel;
        private TextBox CountTextBox;
        private Button AddPartButton;
        private Label InventoryLabel;
        private Label NumberInStorageLabel;
        private Label PartsLabel;
    }
}
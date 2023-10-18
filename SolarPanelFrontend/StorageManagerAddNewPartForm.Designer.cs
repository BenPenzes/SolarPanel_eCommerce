namespace SolarPanelFrontend
{
    partial class StorageManagerAddNewPartForm
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
            this.PartNameLabel = new System.Windows.Forms.Label();
            this.PartDescriptionLabel = new System.Windows.Forms.Label();
            this.CountPerCompartmentLabel = new System.Windows.Forms.Label();
            this.CurrentPriceLabel = new System.Windows.Forms.Label();
            this.PartNameTextBox = new System.Windows.Forms.TextBox();
            this.PartDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CountPerCompartmentTextBox = new System.Windows.Forms.TextBox();
            this.CurrentPriceTextBox = new System.Windows.Forms.TextBox();
            this.AddPartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PartNameLabel
            // 
            this.PartNameLabel.AutoSize = true;
            this.PartNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PartNameLabel.Location = new System.Drawing.Point(24, 42);
            this.PartNameLabel.Name = "PartNameLabel";
            this.PartNameLabel.Size = new System.Drawing.Size(103, 28);
            this.PartNameLabel.TabIndex = 0;
            this.PartNameLabel.Text = "Part Name";
            // 
            // PartDescriptionLabel
            // 
            this.PartDescriptionLabel.AutoSize = true;
            this.PartDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PartDescriptionLabel.Location = new System.Drawing.Point(24, 84);
            this.PartDescriptionLabel.Name = "PartDescriptionLabel";
            this.PartDescriptionLabel.Size = new System.Drawing.Size(151, 28);
            this.PartDescriptionLabel.TabIndex = 0;
            this.PartDescriptionLabel.Text = "Part Description\t";
            // 
            // CountPerCompartmentLabel
            // 
            this.CountPerCompartmentLabel.AutoSize = true;
            this.CountPerCompartmentLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountPerCompartmentLabel.Location = new System.Drawing.Point(24, 179);
            this.CountPerCompartmentLabel.Name = "CountPerCompartmentLabel";
            this.CountPerCompartmentLabel.Size = new System.Drawing.Size(224, 28);
            this.CountPerCompartmentLabel.TabIndex = 0;
            this.CountPerCompartmentLabel.Text = "Count Per Compartment\t";
            // 
            // CurrentPriceLabel
            // 
            this.CurrentPriceLabel.AutoSize = true;
            this.CurrentPriceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentPriceLabel.Location = new System.Drawing.Point(24, 235);
            this.CurrentPriceLabel.Name = "CurrentPriceLabel";
            this.CurrentPriceLabel.Size = new System.Drawing.Size(124, 28);
            this.CurrentPriceLabel.TabIndex = 0;
            this.CurrentPriceLabel.Text = "Current Price";
            // 
            // PartNameTextBox
            // 
            this.PartNameTextBox.Location = new System.Drawing.Point(313, 46);
            this.PartNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PartNameTextBox.Name = "PartNameTextBox";
            this.PartNameTextBox.Size = new System.Drawing.Size(217, 27);
            this.PartNameTextBox.TabIndex = 1;
            // 
            // PartDescriptionTextBox
            // 
            this.PartDescriptionTextBox.Location = new System.Drawing.Point(24, 126);
            this.PartDescriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PartDescriptionTextBox.Name = "PartDescriptionTextBox";
            this.PartDescriptionTextBox.Size = new System.Drawing.Size(506, 27);
            this.PartDescriptionTextBox.TabIndex = 1;
            // 
            // CountPerCompartmentTextBox
            // 
            this.CountPerCompartmentTextBox.Location = new System.Drawing.Point(313, 183);
            this.CountPerCompartmentTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CountPerCompartmentTextBox.Name = "CountPerCompartmentTextBox";
            this.CountPerCompartmentTextBox.Size = new System.Drawing.Size(217, 27);
            this.CountPerCompartmentTextBox.TabIndex = 1;
            // 
            // CurrentPriceTextBox
            // 
            this.CurrentPriceTextBox.Location = new System.Drawing.Point(313, 239);
            this.CurrentPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CurrentPriceTextBox.Name = "CurrentPriceTextBox";
            this.CurrentPriceTextBox.Size = new System.Drawing.Size(217, 27);
            this.CurrentPriceTextBox.TabIndex = 1;
            // 
            // AddPartButton
            // 
            this.AddPartButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddPartButton.Location = new System.Drawing.Point(199, 303);
            this.AddPartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddPartButton.Name = "AddPartButton";
            this.AddPartButton.Size = new System.Drawing.Size(183, 44);
            this.AddPartButton.TabIndex = 2;
            this.AddPartButton.Text = "Add";
            this.AddPartButton.UseVisualStyleBackColor = true;
            this.AddPartButton.Click += new System.EventHandler(this.AddPartButton_Click);
            // 
            // StorageManagerAddNewPartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 387);
            this.Controls.Add(this.AddPartButton);
            this.Controls.Add(this.CurrentPriceTextBox);
            this.Controls.Add(this.CountPerCompartmentTextBox);
            this.Controls.Add(this.PartDescriptionTextBox);
            this.Controls.Add(this.PartNameTextBox);
            this.Controls.Add(this.CurrentPriceLabel);
            this.Controls.Add(this.CountPerCompartmentLabel);
            this.Controls.Add(this.PartDescriptionLabel);
            this.Controls.Add(this.PartNameLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StorageManagerAddNewPartForm";
            this.Text = "StorageManagerAddNewPartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label PartNameLabel;
        private Label PartDescriptionLabel;
        private Label CountPerCompartmentLabel;
        private Label CurrentPriceLabel;
        private TextBox PartNameTextBox;
        private TextBox PartDescriptionTextBox;
        private TextBox CountPerCompartmentTextBox;
        private TextBox CurrentPriceTextBox;
        private Button AddPartButton;
    }
}
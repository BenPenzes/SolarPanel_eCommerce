namespace SolarPanelFrontend
{
    partial class StorageManagerMainForm
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
            this.ShowAllPartsButton = new System.Windows.Forms.Button();
            this.StorageManagerDataGridView = new System.Windows.Forms.DataGridView();
            this.AddNewPartButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.MainFormLabel = new System.Windows.Forms.Label();
            this.SupplyPartsButton = new System.Windows.Forms.Button();
            this.MissingPartsButton = new System.Windows.Forms.Button();
            this.PreorderedPartsButton = new System.Windows.Forms.Button();
            this.ViewStorageButton = new System.Windows.Forms.Button();
            this.PartsButtonsPanel = new System.Windows.Forms.Panel();
            this.StorageButtonsPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.StorageManagerDataGridView)).BeginInit();
            this.PartsButtonsPanel.SuspendLayout();
            this.StorageButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowAllPartsButton
            // 
            this.ShowAllPartsButton.Location = new System.Drawing.Point(17, 16);
            this.ShowAllPartsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowAllPartsButton.Name = "ShowAllPartsButton";
            this.ShowAllPartsButton.Size = new System.Drawing.Size(126, 55);
            this.ShowAllPartsButton.TabIndex = 0;
            this.ShowAllPartsButton.Text = "Show All Parts";
            this.ShowAllPartsButton.UseVisualStyleBackColor = true;
            this.ShowAllPartsButton.Click += new System.EventHandler(this.ShowAllPartsButton_Click);
            // 
            // StorageManagerDataGridView
            // 
            this.StorageManagerDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.StorageManagerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StorageManagerDataGridView.Location = new System.Drawing.Point(40, 88);
            this.StorageManagerDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StorageManagerDataGridView.Name = "StorageManagerDataGridView";
            this.StorageManagerDataGridView.RowHeadersWidth = 51;
            this.StorageManagerDataGridView.RowTemplate.Height = 25;
            this.StorageManagerDataGridView.Size = new System.Drawing.Size(877, 448);
            this.StorageManagerDataGridView.TabIndex = 2;
            // 
            // AddNewPartButton
            // 
            this.AddNewPartButton.Location = new System.Drawing.Point(17, 79);
            this.AddNewPartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddNewPartButton.Name = "AddNewPartButton";
            this.AddNewPartButton.Size = new System.Drawing.Size(126, 55);
            this.AddNewPartButton.TabIndex = 3;
            this.AddNewPartButton.Text = "Add New Part";
            this.AddNewPartButton.UseVisualStyleBackColor = true;
            this.AddNewPartButton.Click += new System.EventHandler(this.AddNewPartButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuitButton.Location = new System.Drawing.Point(1006, 550);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(104, 37);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "QUIT";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MainFormLabel
            // 
            this.MainFormLabel.AutoSize = true;
            this.MainFormLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainFormLabel.Font = new System.Drawing.Font("Cascadia Code", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MainFormLabel.Location = new System.Drawing.Point(45, 20);
            this.MainFormLabel.Name = "MainFormLabel";
            this.MainFormLabel.Size = new System.Drawing.Size(367, 52);
            this.MainFormLabel.TabIndex = 5;
            this.MainFormLabel.Text = "Storage Manager";
            // 
            // SupplyPartsButton
            // 
            this.SupplyPartsButton.Location = new System.Drawing.Point(17, 211);
            this.SupplyPartsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SupplyPartsButton.Name = "SupplyPartsButton";
            this.SupplyPartsButton.Size = new System.Drawing.Size(126, 55);
            this.SupplyPartsButton.TabIndex = 6;
            this.SupplyPartsButton.Text = "Supply Parts";
            this.SupplyPartsButton.UseVisualStyleBackColor = true;
            this.SupplyPartsButton.Click += new System.EventHandler(this.SupplyPartsButton_Click);
            // 
            // MissingPartsButton
            // 
            this.MissingPartsButton.Location = new System.Drawing.Point(17, 77);
            this.MissingPartsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MissingPartsButton.Name = "MissingPartsButton";
            this.MissingPartsButton.Size = new System.Drawing.Size(126, 59);
            this.MissingPartsButton.TabIndex = 7;
            this.MissingPartsButton.Text = "Missing Parts";
            this.MissingPartsButton.UseVisualStyleBackColor = true;
            this.MissingPartsButton.Click += new System.EventHandler(this.MissingPartsButton_Click);
            // 
            // PreorderedPartsButton
            // 
            this.PreorderedPartsButton.Location = new System.Drawing.Point(17, 144);
            this.PreorderedPartsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PreorderedPartsButton.Name = "PreorderedPartsButton";
            this.PreorderedPartsButton.Size = new System.Drawing.Size(126, 59);
            this.PreorderedPartsButton.TabIndex = 8;
            this.PreorderedPartsButton.Text = "Preordered Parts";
            this.PreorderedPartsButton.UseVisualStyleBackColor = true;
            this.PreorderedPartsButton.Click += new System.EventHandler(this.PreorderedPartsButton_Click);
            // 
            // ViewStorageButton
            // 
            this.ViewStorageButton.Location = new System.Drawing.Point(17, 15);
            this.ViewStorageButton.Name = "ViewStorageButton";
            this.ViewStorageButton.Size = new System.Drawing.Size(126, 55);
            this.ViewStorageButton.TabIndex = 9;
            this.ViewStorageButton.Text = "View Storage";
            this.ViewStorageButton.UseVisualStyleBackColor = true;
            this.ViewStorageButton.Click += new System.EventHandler(this.ViewStorageButton_Click);
            // 
            // PartsButtonsPanel
            // 
            this.PartsButtonsPanel.Controls.Add(this.ShowAllPartsButton);
            this.PartsButtonsPanel.Controls.Add(this.AddNewPartButton);
            this.PartsButtonsPanel.Location = new System.Drawing.Point(948, 88);
            this.PartsButtonsPanel.Name = "PartsButtonsPanel";
            this.PartsButtonsPanel.Size = new System.Drawing.Size(162, 148);
            this.PartsButtonsPanel.TabIndex = 10;
            // 
            // StorageButtonsPanel
            // 
            this.StorageButtonsPanel.Controls.Add(this.MissingPartsButton);
            this.StorageButtonsPanel.Controls.Add(this.ViewStorageButton);
            this.StorageButtonsPanel.Controls.Add(this.SupplyPartsButton);
            this.StorageButtonsPanel.Controls.Add(this.PreorderedPartsButton);
            this.StorageButtonsPanel.Location = new System.Drawing.Point(948, 250);
            this.StorageButtonsPanel.Name = "StorageButtonsPanel";
            this.StorageButtonsPanel.Size = new System.Drawing.Size(162, 283);
            this.StorageButtonsPanel.TabIndex = 12;
            // 
            // StorageManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SolarPanelFrontend.Properties.Resources.storage_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1136, 600);
            this.Controls.Add(this.PartsButtonsPanel);
            this.Controls.Add(this.MainFormLabel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.StorageManagerDataGridView);
            this.Controls.Add(this.StorageButtonsPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StorageManagerMainForm";
            this.Text = "StorageManagerMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.StorageManagerDataGridView)).EndInit();
            this.PartsButtonsPanel.ResumeLayout(false);
            this.StorageButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ShowAllPartsButton;
        private DataGridView StorageManagerDataGridView;
        private Button AddNewPartButton;
        private Button QuitButton;
        private Label MainFormLabel;
        private Button SupplyPartsButton;
        private Button MissingPartsButton;
        private Button PreorderedPartsButton;
        private Button ViewStorageButton;
        private Panel PartsButtonsPanel;
        private Panel StorageButtonsPanel;
    }
}
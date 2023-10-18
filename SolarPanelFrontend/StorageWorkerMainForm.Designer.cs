namespace SolarPanelFrontend
{
    partial class StorageWorkerMainForm
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
            this.MainFormLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.StorageWorkerDataGridView = new System.Windows.Forms.DataGridView();
            this.ScheduledProjectsButton = new System.Windows.Forms.Button();
            this.ViewStorageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StorageWorkerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainFormLabel
            // 
            this.MainFormLabel.AutoSize = true;
            this.MainFormLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainFormLabel.Font = new System.Drawing.Font("Cascadia Code", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MainFormLabel.Location = new System.Drawing.Point(14, 12);
            this.MainFormLabel.Name = "MainFormLabel";
            this.MainFormLabel.Size = new System.Drawing.Size(344, 52);
            this.MainFormLabel.TabIndex = 0;
            this.MainFormLabel.Text = "Storage Worker";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.QuitButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuitButton.Location = new System.Drawing.Point(769, 536);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(119, 48);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "QUIT";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // StorageWorkerDataGridView
            // 
            this.StorageWorkerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StorageWorkerDataGridView.Location = new System.Drawing.Point(14, 144);
            this.StorageWorkerDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StorageWorkerDataGridView.Name = "StorageWorkerDataGridView";
            this.StorageWorkerDataGridView.RowHeadersWidth = 51;
            this.StorageWorkerDataGridView.RowTemplate.Height = 25;
            this.StorageWorkerDataGridView.Size = new System.Drawing.Size(874, 384);
            this.StorageWorkerDataGridView.TabIndex = 2;
            this.StorageWorkerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StorageWorkerDataGridView_CellContentClick);
            // 
            // ScheduledProjectsButton
            // 
            this.ScheduledProjectsButton.Location = new System.Drawing.Point(14, 88);
            this.ScheduledProjectsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduledProjectsButton.Name = "ScheduledProjectsButton";
            this.ScheduledProjectsButton.Size = new System.Drawing.Size(128, 48);
            this.ScheduledProjectsButton.TabIndex = 3;
            this.ScheduledProjectsButton.Text = "Scheduled Projects";
            this.ScheduledProjectsButton.UseVisualStyleBackColor = true;
            this.ScheduledProjectsButton.Click += new System.EventHandler(this.ScheduledProjectsButton_Click);
            // 
            // ViewStorageButton
            // 
            this.ViewStorageButton.Location = new System.Drawing.Point(148, 88);
            this.ViewStorageButton.Name = "ViewStorageButton";
            this.ViewStorageButton.Size = new System.Drawing.Size(119, 48);
            this.ViewStorageButton.TabIndex = 4;
            this.ViewStorageButton.Text = "View Storage";
            this.ViewStorageButton.UseVisualStyleBackColor = true;
            this.ViewStorageButton.Click += new System.EventHandler(this.ViewStorageButton_Click);
            // 
            // StorageWorkerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SolarPanelFrontend.Properties.Resources.storage_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.ViewStorageButton);
            this.Controls.Add(this.ScheduledProjectsButton);
            this.Controls.Add(this.StorageWorkerDataGridView);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.MainFormLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StorageWorkerMainForm";
            this.Text = "StorageWorker";
            ((System.ComponentModel.ISupportInitialize)(this.StorageWorkerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label MainFormLabel;
        private Button QuitButton;
        private DataGridView StorageWorkerDataGridView;
        private Button ScheduledProjectsButton;
        private Button ViewStorageButton;
    }
}
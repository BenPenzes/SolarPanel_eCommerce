    namespace SolarPanelFrontend
{
    partial class SpecialistMainForm
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
            this.MyProjectsButton = new System.Windows.Forms.Button();
            this.SpecialistDataGridView = new System.Windows.Forms.DataGridView();
            this.NewProjectButton = new System.Windows.Forms.Button();
            this.AvailablePartsButton = new System.Windows.Forms.Button();
            this.AddPartsToOrderButton = new System.Windows.Forms.Button();
            this.CompleteOrderButton = new System.Windows.Forms.Button();
            this.OrderEntriesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialistDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainFormLabel
            // 
            this.MainFormLabel.AutoSize = true;
            this.MainFormLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainFormLabel.Font = new System.Drawing.Font("Cascadia Code", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MainFormLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.MainFormLabel.Location = new System.Drawing.Point(37, 12);
            this.MainFormLabel.Name = "MainFormLabel";
            this.MainFormLabel.Size = new System.Drawing.Size(275, 52);
            this.MainFormLabel.TabIndex = 0;
            this.MainFormLabel.Text = "Specialist ";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.QuitButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuitButton.Location = new System.Drawing.Point(765, 540);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(115, 44);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "QUIT";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MyProjectsButton
            // 
            this.MyProjectsButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MyProjectsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MyProjectsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.MyProjectsButton.Location = new System.Drawing.Point(37, 92);
            this.MyProjectsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MyProjectsButton.Name = "MyProjectsButton";
            this.MyProjectsButton.Size = new System.Drawing.Size(145, 49);
            this.MyProjectsButton.TabIndex = 2;
            this.MyProjectsButton.Text = "My Projects";
            this.MyProjectsButton.UseVisualStyleBackColor = false;
            this.MyProjectsButton.Click += new System.EventHandler(this.MyProjectsButton_Click);
            // 
            // SpecialistDataGridView
            // 
            this.SpecialistDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.SpecialistDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SpecialistDataGridView.Location = new System.Drawing.Point(37, 149);
            this.SpecialistDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpecialistDataGridView.Name = "SpecialistDataGridView";
            this.SpecialistDataGridView.RowHeadersWidth = 51;
            this.SpecialistDataGridView.RowTemplate.Height = 25;
            this.SpecialistDataGridView.Size = new System.Drawing.Size(691, 419);
            this.SpecialistDataGridView.TabIndex = 3;
            this.SpecialistDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SpecialistDataGridView_CellContentClick);
            // 
            // NewProjectButton
            // 
            this.NewProjectButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.NewProjectButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NewProjectButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.NewProjectButton.Location = new System.Drawing.Point(199, 91);
            this.NewProjectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewProjectButton.Name = "NewProjectButton";
            this.NewProjectButton.Size = new System.Drawing.Size(153, 51);
            this.NewProjectButton.TabIndex = 4;
            this.NewProjectButton.Text = "New Project";
            this.NewProjectButton.UseVisualStyleBackColor = false;
            this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
            // 
            // AvailablePartsButton
            // 
            this.AvailablePartsButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AvailablePartsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AvailablePartsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.AvailablePartsButton.Location = new System.Drawing.Point(747, 200);
            this.AvailablePartsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AvailablePartsButton.Name = "AvailablePartsButton";
            this.AvailablePartsButton.Size = new System.Drawing.Size(115, 51);
            this.AvailablePartsButton.TabIndex = 5;
            this.AvailablePartsButton.Text = "Available Parts";
            this.AvailablePartsButton.UseVisualStyleBackColor = false;
            this.AvailablePartsButton.Visible = false;
            this.AvailablePartsButton.Click += new System.EventHandler(this.AvailablePartsButton_Click);
            // 
            // AddPartsToOrderButton
            // 
            this.AddPartsToOrderButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AddPartsToOrderButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddPartsToOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.AddPartsToOrderButton.Location = new System.Drawing.Point(747, 303);
            this.AddPartsToOrderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddPartsToOrderButton.Name = "AddPartsToOrderButton";
            this.AddPartsToOrderButton.Size = new System.Drawing.Size(115, 53);
            this.AddPartsToOrderButton.TabIndex = 6;
            this.AddPartsToOrderButton.Text = "Add Parts to Order";
            this.AddPartsToOrderButton.UseVisualStyleBackColor = false;
            this.AddPartsToOrderButton.Visible = false;
            this.AddPartsToOrderButton.Click += new System.EventHandler(this.AddPartsToOrderButton_Click);
            // 
            // CompleteOrderButton
            // 
            this.CompleteOrderButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CompleteOrderButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CompleteOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CompleteOrderButton.Location = new System.Drawing.Point(747, 364);
            this.CompleteOrderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompleteOrderButton.Name = "CompleteOrderButton";
            this.CompleteOrderButton.Size = new System.Drawing.Size(115, 59);
            this.CompleteOrderButton.TabIndex = 7;
            this.CompleteOrderButton.Text = "Complete Order";
            this.CompleteOrderButton.UseVisualStyleBackColor = false;
            this.CompleteOrderButton.Visible = false;
            this.CompleteOrderButton.Click += new System.EventHandler(this.CompleteOrderButton_Click);
            // 
            // OrderEntriesButton
            // 
            this.OrderEntriesButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.OrderEntriesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OrderEntriesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.OrderEntriesButton.Location = new System.Drawing.Point(747, 149);
            this.OrderEntriesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OrderEntriesButton.Name = "OrderEntriesButton";
            this.OrderEntriesButton.Size = new System.Drawing.Size(115, 51);
            this.OrderEntriesButton.TabIndex = 8;
            this.OrderEntriesButton.Text = "Order Entries";
            this.OrderEntriesButton.UseVisualStyleBackColor = false;
            this.OrderEntriesButton.Visible = false;
            this.OrderEntriesButton.Click += new System.EventHandler(this.OrderEntriesButton_Click);
            // 
            // SpecialistMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SolarPanelFrontend.Properties.Resources.solar_energy_2157212_1920;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.OrderEntriesButton);
            this.Controls.Add(this.CompleteOrderButton);
            this.Controls.Add(this.AddPartsToOrderButton);
            this.Controls.Add(this.AvailablePartsButton);
            this.Controls.Add(this.NewProjectButton);
            this.Controls.Add(this.SpecialistDataGridView);
            this.Controls.Add(this.MyProjectsButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.MainFormLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SpecialistMainForm";
            this.Text = "Specialist";
            ((System.ComponentModel.ISupportInitialize)(this.SpecialistDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label MainFormLabel;
        private Button QuitButton;
        private Button MyProjectsButton;
        private DataGridView SpecialistDataGridView;
        private Button NewProjectButton;
        private Button AvailablePartsButton;
        private Button AddPartsToOrderButton;
        private Button CompleteOrderButton;
        private Button OrderEntriesButton;
    }
}
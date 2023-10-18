namespace SolarPanelFrontend
{
    partial class LoginForm
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
            this.LoginFormPanel = new System.Windows.Forms.Panel();
            this.PasswordIsEmptyLabel = new System.Windows.Forms.Label();
            this.EmailIsEmptyLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.MainFormLabel = new System.Windows.Forms.Label();
            this.LoginFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginFormPanel
            // 
            this.LoginFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginFormPanel.BackColor = System.Drawing.Color.DimGray;
            this.LoginFormPanel.Controls.Add(this.PasswordIsEmptyLabel);
            this.LoginFormPanel.Controls.Add(this.EmailIsEmptyLabel);
            this.LoginFormPanel.Controls.Add(this.LoginButton);
            this.LoginFormPanel.Controls.Add(this.PasswordLabel);
            this.LoginFormPanel.Controls.Add(this.EmailLabel);
            this.LoginFormPanel.Controls.Add(this.PasswordTextBox);
            this.LoginFormPanel.Controls.Add(this.EmailTextBox);
            this.LoginFormPanel.Location = new System.Drawing.Point(273, 165);
            this.LoginFormPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginFormPanel.Name = "LoginFormPanel";
            this.LoginFormPanel.Size = new System.Drawing.Size(398, 316);
            this.LoginFormPanel.TabIndex = 1;
            // 
            // PasswordIsEmptyLabel
            // 
            this.PasswordIsEmptyLabel.AutoSize = true;
            this.PasswordIsEmptyLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordIsEmptyLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PasswordIsEmptyLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordIsEmptyLabel.Location = new System.Drawing.Point(78, 213);
            this.PasswordIsEmptyLabel.Name = "PasswordIsEmptyLabel";
            this.PasswordIsEmptyLabel.Size = new System.Drawing.Size(0, 25);
            this.PasswordIsEmptyLabel.TabIndex = 3;
            // 
            // EmailIsEmptyLabel
            // 
            this.EmailIsEmptyLabel.AutoSize = true;
            this.EmailIsEmptyLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmailIsEmptyLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EmailIsEmptyLabel.ForeColor = System.Drawing.Color.Red;
            this.EmailIsEmptyLabel.Location = new System.Drawing.Point(78, 116);
            this.EmailIsEmptyLabel.Name = "EmailIsEmptyLabel";
            this.EmailIsEmptyLabel.Size = new System.Drawing.Size(0, 25);
            this.EmailIsEmptyLabel.TabIndex = 3;
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSize = true;
            this.LoginButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginButton.ForeColor = System.Drawing.Color.DimGray;
            this.LoginButton.Location = new System.Drawing.Point(118, 252);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(0);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(138, 40);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PasswordLabel.Location = new System.Drawing.Point(77, 149);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(94, 24);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmailLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmailLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EmailLabel.Location = new System.Drawing.Point(78, 52);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(59, 24);
            this.EmailLabel.TabIndex = 1;
            this.EmailLabel.Text = "Email";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(77, 179);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(237, 27);
            this.PasswordTextBox.TabIndex = 0;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.EmailTextBox.Location = new System.Drawing.Point(78, 81);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(237, 27);
            this.EmailTextBox.TabIndex = 0;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPictureBox.Image = global::SolarPanelFrontend.Properties.Resources.Solar_Logo;
            this.LogoPictureBox.Location = new System.Drawing.Point(54, -59);
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(160, 180);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 3;
            this.LogoPictureBox.TabStop = false;
            // 
            // MainFormLabel
            // 
            this.MainFormLabel.AutoSize = true;
            this.MainFormLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainFormLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainFormLabel.Location = new System.Drawing.Point(199, 24);
            this.MainFormLabel.Name = "MainFormLabel";
            this.MainFormLabel.Size = new System.Drawing.Size(395, 52);
            this.MainFormLabel.TabIndex = 4;
            this.MainFormLabel.Text = "Solar Panel Project";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SolarPanelFrontend.Properties.Resources.solar_panel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.MainFormLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.LoginFormPanel);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.LoginFormPanel.ResumeLayout(false);
            this.LoginFormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel LoginFormPanel;
        private TextBox EmailTextBox;
        private Label PasswordLabel;
        private Label EmailLabel;
        private TextBox PasswordTextBox;
        private Button LoginButton;
        private PictureBox LogoPictureBox;
        private Label MainFormLabel;
        private Label EmailIsEmptyLabel;
        private Label PasswordIsEmptyLabel;
    }
}
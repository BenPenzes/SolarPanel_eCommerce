using System.Text;
using SolarPanelBackend.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace SolarPanelFrontend
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoginFormPanel.BackColor = Color.FromArgb(170, 61, 72, 73); // transparent panel
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email = ""; string password = ""; string hashedPassword = "";
            if (EmailTextBox.Text == "")
            {
                EmailIsEmptyLabel.Text = "Please enter an email!";
            }
            else
            {
                EmailIsEmptyLabel.Text = "";
                email = EmailTextBox.Text;
            }
            if (PasswordTextBox.Text == "")
            {
                PasswordIsEmptyLabel.Text = "Please enter a password!";
            }
            else
            {
                PasswordIsEmptyLabel.Text = "";
                password = PasswordTextBox.Text;
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    StringBuilder result = new StringBuilder();
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        result.Append(bytes[i].ToString("x2"));
                    }
                    hashedPassword = result.ToString();
                }
            }
            if (email != "" && password != "")
            {
                LoginInformationModel login = new LoginInformationModel(email, hashedPassword);
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PostAsJsonAsync("api/Person/Login", login).Result;
                if (response.IsSuccessStatusCode)
                {
                    KeyValuePair<string, int> loginInfo = response.Content.ReadAsAsync<KeyValuePair<string, int>>().Result;
                    string job = loginInfo.Key;
                    if (job == "Storage Manager")
                    {
                        this.Hide();
                        StorageManagerMainForm managerForm = new();
                        managerForm.Show();
                    }
                    else if (job == "Admin")
                    {
                        this.Hide();
                        AdminForm adminForm = new();
                        adminForm.Show();
                    }
                    else if (job == "Storage Worker")
                    {
                        this.Hide();
                        StorageWorkerMainForm workerForm = new();
                        workerForm.Show();
                    }
                    else if (job == "Specialist")
                    {
                        int ID = loginInfo.Value;
                        this.Hide();
                        SpecialistMainForm specialistForm = new(ID);
                        specialistForm.Show();
                    }
                    else
                    {
                        MessageBox.Show($"Error! Job with name \"{job}\" doesn't exist!");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
        }
        private void LoginFormPanel_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddLine(20, 0, LoginFormPanel.Width - 20, 0);
            path.AddArc(LoginFormPanel.Width - 20, 0, 20, 20, 270, 90);
            path.AddLine(LoginFormPanel.Width, 20, LoginFormPanel.Width, LoginFormPanel.Height - 20);
            path.AddArc(LoginFormPanel.Width - 20, LoginFormPanel.Height - 20, 20, 20, 0, 90);
            path.AddLine(LoginFormPanel.Width - 20, LoginFormPanel.Height, 20, LoginFormPanel.Height);
            path.AddArc(0, LoginFormPanel.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();
            LoginFormPanel.Region = new Region(path);
        }
    }
}

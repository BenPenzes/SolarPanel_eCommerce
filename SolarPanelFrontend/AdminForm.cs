using System.Text;
using System.Security.Cryptography;
using SolarPanelBackend.Models;
using System.Net.Http.Headers;

namespace SolarPanelFrontend
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            FormPanel.BackColor = Color.FromArgb(70, 70, 130, 180); // transparent panel
            JobComboBox.Items.Add("Specialist");
            JobComboBox.Items.Add("Storage Worker");
            JobComboBox.Items.Add("Storage Manager");
        }
        private void FormPanel_Paint(object sender, PaintEventArgs e)
        {
            // rounding panel corners
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(); 
            path.StartFigure();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddLine(20, 0, FormPanel.Width - 20, 0);
            path.AddArc(FormPanel.Width - 20, 0, 20, 20, 270, 90);
            path.AddLine(FormPanel.Width, 20, FormPanel.Width, FormPanel.Height - 20);
            path.AddArc(FormPanel.Width - 20, FormPanel.Height - 20, 20, 20, 0, 90);
            path.AddLine(FormPanel.Width - 20, FormPanel.Height, 20, FormPanel.Height);
            path.AddArc(0, FormPanel.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();
            FormPanel.Region = new Region(path); // drawing the panel
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            string firstName = "", lastName = "", email = "", job = "", password = "", hashedPassword = "";
            if (FirstNameTextBox.Text == "")
            {
                FirstNameIsEmptyLabel.Text = "Please enter your first name!";
            } 
            else
            {
                firstName = FirstNameTextBox.Text;
                FirstNameIsEmptyLabel.Text = "";
            } 

            if (LastNameTextBox.Text == "")
            {
                LastNameIsEmptyLabel.Text = "Please enter a last name!";
            } 
            else
            {
                lastName = LastNameTextBox.Text;
                LastNameIsEmptyLabel.Text = "";
            }

            if (EmailTextBox.Text == "")
            {
                EmailIsEmptyLabel.Text = "Please enter an email!";
            } 
            else
            {
                email = EmailTextBox.Text;
                EmailIsEmptyLabel.Text = "";
            }

            if (JobComboBox.SelectedItem == null)
            {
                JobIsEmptyLabel.Text = "Please select a job!";
            } 
            else
            {
                job = JobComboBox.SelectedItem.ToString();
                JobIsEmptyLabel.Text = "";
            }

            if (PasswordTextBox.Text == "")
            {
                PasswordIsEmptyLabel.Text = "Please enter a password!";
            } 
            else
            {
                password = PasswordTextBox.Text;
                PasswordIsEmptyLabel.Text = "";
                using (SHA256 sha256Hash = SHA256.Create()) // hash pw with sha-256 algorithm
                {
                    StringBuilder result = new(); // store result as a hexadecimal string
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        result.Append(bytes[i].ToString("x2"));
                    }
                    hashedPassword = result.ToString(); // convert to string (32 chars long)
                }
            }

            if (firstName != "" && lastName != "" && email != "" && password != "" && job != "")
            { 
                LoginInformationModel login = new(email, hashedPassword);
                PersonModel newPerson = new(0, firstName, lastName, job, login, null);
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7087"); // base uri of the api
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PostAsJsonAsync("api/Person/NewPerson", newPerson).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.Content.ReadAsStringAsync().Result);
                    FirstNameTextBox.Text = "";
                    LastNameTextBox.Text = "";
                    EmailTextBox.Text = "";
                    PasswordTextBox.Text = "";
                } else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new();
            loginForm.Show();
        }
    }
}

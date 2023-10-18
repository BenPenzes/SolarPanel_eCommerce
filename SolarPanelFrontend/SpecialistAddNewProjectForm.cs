using SolarPanelBackend.Models;
using System.Net.Http.Headers;

namespace SolarPanelFrontend
{
    public partial class SpecialistAddNewProjectForm : Form
    {
        readonly int UserID;
        public SpecialistAddNewProjectForm(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }
        private void AddProject_Click(object sender, EventArgs e)
        {
            string projectName = ProjectNameTextBox.Text;
            string description = ProjectDescriptionTextBox.Text;
            string clientName = ClientNameTextBox.Text;
            string location = LocationTextBox.Text;
            int estimatedHours = Convert.ToInt32(EstimatedHoursTextBox.Text);
            int pricePerHour = Convert.ToInt32(PricePerHourTextBox.Text);
            ProjectModel newProject = new(null, projectName, 0, UserID, description, clientName, location, estimatedHours, pricePerHour);
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7087"); 
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.PostAsJsonAsync("api/Project/NewProject", newProject).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Success! New project with name \"{projectName}\" created!");
                ProjectNameTextBox.Text = "";
                ProjectDescriptionTextBox.Text = "";
                ClientNameTextBox.Text = "";
                LocationTextBox.Text = "";
                EstimatedHoursTextBox.Text = "";
                PricePerHourTextBox.Text = "";
            }
            else
            {
                MessageBox.Show(response.ReasonPhrase);
            }
        }
    }
}

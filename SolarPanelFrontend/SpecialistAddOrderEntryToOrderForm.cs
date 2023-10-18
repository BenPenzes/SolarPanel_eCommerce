using Newtonsoft.Json;
using SolarPanelBackend.Dtos;
using SolarPanelBackend.Models;
using System.Net.Http.Json;
using static SolarPanelBackend.Models.ProjectModel;

namespace SolarPanelFrontend
{
    public partial class SpecialistAddOrderEntryToOrderForm : Form
    {
        readonly int OrderID;
        readonly int ProjectID;
        List<PartModel> Parts;
        public SpecialistAddOrderEntryToOrderForm(int OrderID, int ProjectID)
        {
            InitializeComponent();
            this.OrderID = OrderID;
            this.ProjectID = ProjectID;
            LoadPartNames();
        }
        public async void LoadPartNames()
        {
            PartNamesComboBox.Items.Clear();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Part/ListAllParts");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Parts = JsonConvert.DeserializeObject<List<PartModel>>(json);
                    foreach (var part in Parts)
                    {
                        PartNamesComboBox.Items.Add(part.PartName);
                    }
                    PartNamesComboBox.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void AddButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                int partID = Convert.ToInt32(Parts[PartNamesComboBox.SelectedIndex].PartID.ToString());
                OrderEntryModel orderEntryModel = new(partID, Convert.ToInt32(CountTextBox.Text.ToString()), 1);
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"api/Order/AddOrderEntryToOrder/{OrderID}", orderEntryModel);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success! " + Parts[PartNamesComboBox.SelectedIndex].PartName + " added to the order!");
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync($"api/Project/GetProjectStatus/{ProjectID}");
                if (response.IsSuccessStatusCode)
                {
                    ProjectStatus projectStatus = await response.Content.ReadAsAsync<ProjectStatus>();
                    if (projectStatus == ProjectStatus.NEW)
                    {
                        UpdateProjectStatusDto updateProjectStatusDto = new(ProjectID, ProjectStatus.DRAFT);
                        await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{ProjectID}", updateProjectStatusDto);
                        MessageBox.Show("Project status updated to DRAFT!");
                    }
                }
            }
            CountTextBox.Text = "";
            LoadPartNames();
        }
        private void PartNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartNamesComboBox.SelectedIndex != -1)
                InventoryLabel.Text = Parts[PartNamesComboBox.SelectedIndex].NumInStorage.ToString();
        }
    }

}

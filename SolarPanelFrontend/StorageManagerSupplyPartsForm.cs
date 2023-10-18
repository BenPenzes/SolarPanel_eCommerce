using Newtonsoft.Json;
using SolarPanelBackend.Models;

namespace SolarPanelFrontend
{
    public partial class StorageManagerSupplyPartsForm : Form
    {
        List<PartModel> parts;
        public StorageManagerSupplyPartsForm()
        {
            InitializeComponent();
            LoadParts();
        }
        public async void LoadParts()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Part/ListAllParts");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    this.parts = JsonConvert.DeserializeObject<List<PartModel>>(json);
                    foreach (var part in this.parts)
                    {
                        PartsComboBox.Items.Add(part.PartName);
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void SupplyPartsButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                int partID = Convert.ToInt32(parts[PartsComboBox.SelectedIndex].PartID.ToString());
                int SupplyPartCount = Convert.ToInt32(PartCountTextBox.Text);
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync($"api/Storage/SupplyParts/{partID}/{SupplyPartCount}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Success! {SupplyPartCount} pieces of " + parts[PartsComboBox.SelectedIndex].PartName + " supplied!");
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
    }
}

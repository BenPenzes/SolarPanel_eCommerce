using SolarPanelBackend.Models;
using System.Net.Http.Headers;

namespace SolarPanelFrontend
{
    public partial class StorageManagerAddNewPartForm : Form
    {
        public StorageManagerAddNewPartForm()
        {
            InitializeComponent();
        }
        private void AddPartButton_Click(object sender, EventArgs e)
        {
            string partName = PartNameTextBox.Text;
            string partDescription = PartDescriptionTextBox.Text;
            int countPerCompartment = Int32.Parse(CountPerCompartmentTextBox.Text);
            decimal currentPrice = Convert.ToDecimal(CurrentPriceTextBox.Text);
            PartModel part = new(null, partName, partDescription, countPerCompartment, currentPrice, null);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PostAsJsonAsync("api/Part/NewPart", part).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.Content.ReadAsStringAsync().Result);
                    PartNameTextBox.Text = "";
                    PartDescriptionTextBox.Text = "";
                    CountPerCompartmentTextBox.Text = "";
                    CurrentPriceTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
    }
}
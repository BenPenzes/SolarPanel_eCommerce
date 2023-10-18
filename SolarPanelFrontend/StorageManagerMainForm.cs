using System.Net.Http.Headers;
using Newtonsoft.Json;
using SolarPanelBackend.Models;
using System.Net.Http.Json;
using SolarPanelBackend.Dtos;

namespace SolarPanelFrontend
{
    public partial class StorageManagerMainForm : Form
    {
        public StorageManagerMainForm()
        {
            InitializeComponent();
            this.StorageManagerDataGridView.CellEndEdit += new DataGridViewCellEventHandler(this.StorageManagerDataGridView_CellEndEdit);
        }
        private async void ShowAllPartsButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Part/ListAllParts");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<PartModel> parts = JsonConvert.DeserializeObject<List<PartModel>>(json);
                    StorageManagerDataGridView.Rows.Clear();
                    StorageManagerDataGridView.Columns.Clear();
                    StorageManagerDataGridView.Columns.Add("PartID", "Part ID");
                    StorageManagerDataGridView.Columns.Add("PartName", "Part Name");
                    StorageManagerDataGridView.Columns.Add("PartDescription", "Part Description");
                    StorageManagerDataGridView.Columns.Add("CountPerCompartment", "Count Per Compartment");
                    StorageManagerDataGridView.Columns.Add("CurrentPrice", "Current Price (EUR)");
                    StorageManagerDataGridView.Columns.Add("NumInStorage", "Number In Storage");
                    StorageManagerDataGridView.Columns["PartID"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartName"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartDescription"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["NumInStorage"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartID"].Visible = false;
                    foreach (var part in parts)
                    {
                        StorageManagerDataGridView.Rows.Add(part.PartID, part.PartName, part.PartDescription, part.CountPerCompartment, part.CurrentPrice, part.NumInStorage);
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private void AddNewPartButton_Click(object sender, EventArgs e)
        {
            StorageManagerAddNewPartForm addForm = new();
            addForm.Show();
        }
        private async void ViewStorageButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Storage/ViewStorage");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Tuple<List<int>, string>> compartments = JsonConvert.DeserializeObject<List<Tuple<List<int>, string>>>(json); // [row, column, level, part count], part name
                    StorageManagerDataGridView.Rows.Clear();
                    StorageManagerDataGridView.Columns.Clear();
                    StorageManagerDataGridView.Columns.Add("Row", "Row");
                    StorageManagerDataGridView.Columns.Add("Column", "Column");
                    StorageManagerDataGridView.Columns.Add("Level", "Level");
                    StorageManagerDataGridView.Columns.Add("PartName", "Part Name");
                    StorageManagerDataGridView.Columns.Add("PartCount", "Part Count");
                    StorageManagerDataGridView.Columns["Row"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["Column"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["Level"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartName"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartCount"].ReadOnly = true;
                    foreach (var compartment in compartments)
                    {
                        StorageManagerDataGridView.Rows.Add(compartment.Item1[0], compartment.Item1[1], compartment.Item1[2], compartment.Item2, compartment.Item2 == "" ? "" : compartment.Item1[3]);
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void MissingPartsButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Part/ListPartsNotInStorage");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<PartModel> missingParts = JsonConvert.DeserializeObject<List<PartModel>>(json);
                    StorageManagerDataGridView.Rows.Clear();
                    StorageManagerDataGridView.Columns.Clear();
                    StorageManagerDataGridView.Columns.Add("PartID", "Part ID");
                    StorageManagerDataGridView.Columns.Add("PartName", "Part Name");
                    StorageManagerDataGridView.Columns.Add("PartDescription", "Part Description");
                    StorageManagerDataGridView.Columns.Add("CountPerCompartment", "Count Per Compartment");
                    StorageManagerDataGridView.Columns["PartID"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartName"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartDescription"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["CountPerCompartment"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PartID"].Visible = false;
                    foreach (var part in missingParts)
                    {
                        StorageManagerDataGridView.Rows.Add(part.PartID, part.PartName, part.PartDescription, part.CountPerCompartment, part.CurrentPrice, part.NumInStorage);
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void PreorderedPartsButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Part/ListAllPartsPreordered");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Tuple<string, string, int>> parts = JsonConvert.DeserializeObject<List<Tuple<string, string, int>>>(json);
                    StorageManagerDataGridView.Rows.Clear();
                    StorageManagerDataGridView.Columns.Clear();
                    StorageManagerDataGridView.Columns.Add("PartName", "Part Name");
                    StorageManagerDataGridView.Columns.Add("ProjectName", "Project Name");
                    StorageManagerDataGridView.Columns.Add("PreorderCount", "Preorder Count");
                    StorageManagerDataGridView.Columns["PartName"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["ProjectName"].ReadOnly = true;
                    StorageManagerDataGridView.Columns["PreorderCount"].ReadOnly = true;
                    foreach (var part in parts)
                    {
                        StorageManagerDataGridView.Rows.Add(part.Item1, part.Item2, part.Item3);
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private void SupplyPartsButton_Click(object sender, EventArgs e)
        {
            StorageManagerSupplyPartsForm supplyParts = new();
            supplyParts.Show();
        }
        private async void StorageManagerDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell priceCell = StorageManagerDataGridView.Rows[e.RowIndex].Cells["CurrentPrice"];
            DataGridViewCell compartmentCell;
            int partId = (int)StorageManagerDataGridView.Rows[e.RowIndex].Cells["PartID"].Value;
            decimal newPrice = decimal.Parse(priceCell.FormattedValue.ToString());
            int newCountPerCompartment;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                UpdatePriceDto part = new(partId, newPrice);
                var response = await httpClient.PatchAsJsonAsync($"api/Part/UpdatePartPrice/{partId}", part);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
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

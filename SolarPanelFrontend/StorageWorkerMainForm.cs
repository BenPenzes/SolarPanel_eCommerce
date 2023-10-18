using Newtonsoft.Json;
using SolarPanelBackend.Dtos;
using SolarPanelBackend.Models;
using System.Net.Http.Json;
using static SolarPanelBackend.Models.ProjectModel;

namespace SolarPanelFrontend
{
    public partial class StorageWorkerMainForm : Form
    {
        int OrderID;
        public StorageWorkerMainForm()
        {
            InitializeComponent();
            ShowScheduledProjects();
        }
        private async void ShowScheduledProjects()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync("api/Project/ListAllProjects");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<ProjectModel> projects = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
                    DataGridViewButtonColumn fullfillOrderColumn = new();
                    fullfillOrderColumn.HeaderText = "";
                    fullfillOrderColumn.Name = "fulfillOrder";
                    fullfillOrderColumn.Text = "Fullfill Order";
                    fullfillOrderColumn.UseColumnTextForButtonValue = true;
                    DataGridViewButtonColumn showPartsInStorageColumn = new();
                    showPartsInStorageColumn.HeaderText = "";
                    showPartsInStorageColumn.Name = "ShowPartsInStorage";
                    showPartsInStorageColumn.Text = "Show Parts in Storage";
                    showPartsInStorageColumn.UseColumnTextForButtonValue = true;
                    DataGridViewButtonColumn showOrderColumn = new();
                    showOrderColumn.HeaderText = "";
                    showOrderColumn.Name = "ShowOrder";
                    showOrderColumn.Text = "Show Order";
                    showOrderColumn.UseColumnTextForButtonValue = true;
                    StorageWorkerDataGridView.Rows.Clear();
                    StorageWorkerDataGridView.Columns.Clear();
                    StorageWorkerDataGridView.Columns.Add("ProjectName", "Project Name");
                    StorageWorkerDataGridView.Columns.Add("ProjectID", "Project ID");
                    StorageWorkerDataGridView.Columns.Add("SpecialistID", "Specialist ID");
                    StorageWorkerDataGridView.Columns.Add("MyStatus", "My Status");
                    StorageWorkerDataGridView.Columns.Add("ProjectDescription", "Project Description");
                    StorageWorkerDataGridView.Columns.Add("ClientName", "ClientName");
                    StorageWorkerDataGridView.Columns.Add("Location", "Location");
                    StorageWorkerDataGridView.Columns.Add("EstimatedHours", "Estimated Hours");
                    StorageWorkerDataGridView.Columns.Add("PricePerHour", "Price Per Hour");
                    StorageWorkerDataGridView.Columns.Add(fullfillOrderColumn);
                    StorageWorkerDataGridView.Columns.Add(showPartsInStorageColumn);
                    StorageWorkerDataGridView.Columns.Add(showOrderColumn);
                    StorageWorkerDataGridView.Columns["ProjectName"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["ProjectID"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["SpecialistID"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["MyStatus"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["ProjectDescription"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["ClientName"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["Location"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["EstimatedHours"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["PricePerHour"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["ProjectID"].Visible = false;
                    StorageWorkerDataGridView.Columns["SpecialistID"].Visible = false;
                    foreach (var project in projects)
                    {
                        response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{project.ProjectID}");
                        if (response.IsSuccessStatusCode)
                        {
                            OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                        }
                        if (OrderID != -1 && project.MyStatus == ProjectStatus.SCHEDULED)
                        {
                            StorageWorkerDataGridView.Rows.Add(project.ProjectName, project.ProjectID, project.SpecialistID, project.MyStatus, project.ProjectDescription, project.ClientName, project.Location, project.EstimatedHours, project.PricePerHour);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void ScheduledProjectsButton_Click(object sender, EventArgs e)
        {
            ShowScheduledProjects();
        }
        private async void StorageWorkerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int projectID;
            if (e.ColumnIndex == 9) // Fullfill Order button
            {
                projectID = Convert.ToInt32(StorageWorkerDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7087");
                    UpdateProjectStatusDto updateProjectStatusDto = new(projectID, ProjectStatus.INPROGRESS);
                    StorageWorkerDataGridView.Rows[e.RowIndex].Cells[3].Value = ProjectStatus.INPROGRESS.ToString();
                    HttpResponseMessage response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{projectID}");
                    if (response.IsSuccessStatusCode)
                    {
                        OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                    }
                    response = await httpClient.GetAsync($"api/Storage/FulfillOrder/{OrderID}");
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(response.ReasonPhrase);
                    }
                    response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{projectID}", updateProjectStatusDto);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success! Order fullfilled!");
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase);
                    }
                    ShowScheduledProjects();
                }
            }
            else if (e.ColumnIndex == 10) // List the ordered parts and where they are in the storage
            {
                projectID = Convert.ToInt32(StorageWorkerDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7087");
                    HttpResponseMessage response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{projectID}");
                    if (response.IsSuccessStatusCode)
                    {
                        OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                    }
                    response = await httpClient.GetAsync($"api/Storage/ListPartsOfOrderInStorage/{OrderID}");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var storage = JsonConvert.DeserializeObject<List<Tuple<List<int>, string>>>(json); // [Row, Column, Level], PartName
                        StorageWorkerDataGridView.Rows.Clear();
                        StorageWorkerDataGridView.Columns.Clear();
                        StorageWorkerDataGridView.Columns.Add("Partname", "Part name");
                        StorageWorkerDataGridView.Columns.Add("Row", "Row");
                        StorageWorkerDataGridView.Columns.Add("Column", "Column");
                        StorageWorkerDataGridView.Columns.Add("Level", "Level");
                        StorageWorkerDataGridView.Columns.Add("PartCount", "Part Count");
                        StorageWorkerDataGridView.Columns["Partname"].ReadOnly = true;
                        StorageWorkerDataGridView.Columns["Row"].ReadOnly = true;
                        StorageWorkerDataGridView.Columns["Column"].ReadOnly = true;
                        StorageWorkerDataGridView.Columns["Level"].ReadOnly = true;
                        StorageWorkerDataGridView.Columns["PartCount"].ReadOnly = true;
                        foreach (var compartment in storage)
                        {
                            StorageWorkerDataGridView.Rows.Add(compartment.Item2, compartment.Item1[0], compartment.Item1[1], compartment.Item1[2], compartment.Item1[3]);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase);
                    }
                }
            }
            else if (e.ColumnIndex == 11) // Listing information of the Order
            {
                projectID = Convert.ToInt32(StorageWorkerDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7087");
                    HttpResponseMessage response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{projectID}");
                    if (response.IsSuccessStatusCode)
                    {
                        OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                    }
                    response = await httpClient.GetAsync($"api/Order/ListOrderEntriesOfOrder/{OrderID}");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var orderEntries = JsonConvert.DeserializeObject<List<Tuple<string, int, int>>>(json);
                        StorageWorkerDataGridView.Rows.Clear();
                        StorageWorkerDataGridView.Columns.Clear();
                        StorageWorkerDataGridView.Columns.Add("Partname", "Part name");
                        StorageWorkerDataGridView.Columns.Add("PartCount", "Part Count");
                        StorageWorkerDataGridView.Columns["Partname"].ReadOnly = true;
                        StorageWorkerDataGridView.Columns["PartCount"].ReadOnly = true;
                        foreach (var entry in orderEntries)
                        {
                            StorageWorkerDataGridView.Rows.Add(entry.Item1, entry.Item2);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase);
                    }
                }
            }
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
                    List<Tuple<List<int>, string>> compartments = JsonConvert.DeserializeObject<List<Tuple<List<int>, string>>>(json);
                    StorageWorkerDataGridView.Rows.Clear();
                    StorageWorkerDataGridView.Columns.Clear();
                    StorageWorkerDataGridView.Columns.Add("Row", "Row");
                    StorageWorkerDataGridView.Columns.Add("Column", "Column");
                    StorageWorkerDataGridView.Columns.Add("Level", "Level");
                    StorageWorkerDataGridView.Columns.Add("PartName", "Part Name");
                    StorageWorkerDataGridView.Columns.Add("PartCount", "Part Count");
                    StorageWorkerDataGridView.Columns["Row"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["Column"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["level"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["PartName"].ReadOnly = true;
                    StorageWorkerDataGridView.Columns["PartCount"].ReadOnly = true;
                    foreach (var compartment in compartments)
                    {
                        StorageWorkerDataGridView.Rows.Add(compartment.Item1[0], compartment.Item1[1], compartment.Item1[2], compartment.Item2, compartment.Item2 == "" ? "" : compartment.Item1[3]);
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm backForm = new();
            backForm.Show();
        }
    }
}

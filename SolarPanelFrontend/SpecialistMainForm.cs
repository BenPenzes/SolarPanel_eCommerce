using Newtonsoft.Json;
using SolarPanelBackend.Dtos;
using SolarPanelBackend.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static SolarPanelBackend.Models.ProjectModel;

namespace SolarPanelFrontend
{
    public partial class SpecialistMainForm : Form
    {
        readonly int UserID;
        int OrderID;
        int ProjectID = 0;
        public SpecialistMainForm(int UserID)
        {
            InitializeComponent();
            SpecialistDataGridView.CellEndEdit += new DataGridViewCellEventHandler(this.MainDataGridView_CellEndEdit);
            this.UserID = UserID;
        }
        private async void MainDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell EstimatedHoursCell = SpecialistDataGridView.Rows[e.RowIndex].Cells["EstimatedHours"];
            DataGridViewCell PricePerHoursCell = SpecialistDataGridView.Rows[e.RowIndex].Cells["PricePerHour"];
            int ProjectID = (int)SpecialistDataGridView.Rows[e.RowIndex].Cells["ProjectID"].Value;
            int newEstimatedHours = Convert.ToInt32(EstimatedHoursCell.Value.ToString());
            int newPricePerHours = Convert.ToInt32(PricePerHoursCell.Value.ToString());
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                UpdateProjectEstimatedHoursDto estimatedHoursDto = new(ProjectID, newEstimatedHours);
                var response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectEstimatedHours/{ProjectID}", estimatedHoursDto);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
                UpdatePricePerHourDto pricePerHourDto = new(ProjectID, newPricePerHours);
                response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectPricePerHour/{ProjectID}", pricePerHourDto);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void ShowMyProjects()
        {
            string status = "";
            int priceOfOrder = 0;
            this.AvailablePartsButton.Visible = false;
            this.OrderEntriesButton.Visible = false;
            this.AddPartsToOrderButton.Visible = false;
            this.CompleteOrderButton.Visible = false;
            using (var httpClient = new HttpClient())
            {
                int id = UserID;
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync($"api/Project/ListAllProjectsOfSpecialist/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<ProjectModel> projects = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
                    DataGridViewButtonColumn closeCompleted = new();
                    closeCompleted.HeaderText = "";
                    closeCompleted.Name = "closeCompleted";
                    closeCompleted.Text = "Completed";
                    closeCompleted.UseColumnTextForButtonValue = true;
                    DataGridViewButtonColumn closeFailed = new();
                    closeFailed.HeaderText = "";
                    closeFailed.Name = "closeFailed";
                    closeFailed.Text = "Failed";
                    closeFailed.UseColumnTextForButtonValue = true;
                    DataGridViewButtonColumn buttonColumn = new();
                    buttonColumn.HeaderText = "";
                    buttonColumn.Name = "buttonColumn";
                    buttonColumn.Text = "Order";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    SpecialistDataGridView.Rows.Clear();
                    SpecialistDataGridView.Columns.Clear();
                    SpecialistDataGridView.Columns.Add("ProjectID", "Project ID");
                    SpecialistDataGridView.Columns.Add("ProjectName", "Project Name");
                    SpecialistDataGridView.Columns.Add("SpecialistID", "Specialist ID");
                    SpecialistDataGridView.Columns.Add("ProjectStatus", "Project Status");
                    SpecialistDataGridView.Columns.Add("ProjectDescription", "Project Description");
                    SpecialistDataGridView.Columns.Add("ClientName", "Client Name");
                    SpecialistDataGridView.Columns.Add("Location", "Location");
                    SpecialistDataGridView.Columns.Add("EstimatedHours", "Estimated Hours");
                    SpecialistDataGridView.Columns.Add("PricePerHour", "Price Per Hour");
                    SpecialistDataGridView.Columns.Add("FullPrice", " Full Price");
                    SpecialistDataGridView.Columns.Add(buttonColumn);
                    SpecialistDataGridView.Columns.Add(closeCompleted);
                    SpecialistDataGridView.Columns.Add(closeFailed);
                    SpecialistDataGridView.Columns["ProjectID"].ReadOnly = true;
                    SpecialistDataGridView.Columns["ProjectName"].ReadOnly = true;
                    SpecialistDataGridView.Columns["SpecialistID"].ReadOnly = true;
                    SpecialistDataGridView.Columns["ProjectStatus"].ReadOnly = true;
                    SpecialistDataGridView.Columns["ProjectDescription"].ReadOnly = true;
                    SpecialistDataGridView.Columns["ClientName"].ReadOnly = true;
                    SpecialistDataGridView.Columns["Location"].ReadOnly = true;
                    SpecialistDataGridView.Columns["FullPrice"].ReadOnly = true;
                    SpecialistDataGridView.Columns["ProjectID"].Visible = false;
                    SpecialistDataGridView.Columns["SpecialistID"].Visible = false;
                    foreach (var project in projects)
                    {
                        response = await httpClient.GetAsync($"api/Project/GetProjectStatus/{project.ProjectID}");
                        if (response.IsSuccessStatusCode)
                        {
                            status = await response.Content.ReadAsStringAsync();
                        }
                        if (status == "3")
                        {
                            response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{project.ProjectID}");
                            if (response.IsSuccessStatusCode)
                            {
                                OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                            }
                            response = await httpClient.GetAsync($"api/Order/CalculatePriceOfOrder/{project.ProjectID}/{OrderID}");
                            if (response.IsSuccessStatusCode)
                            {
                                priceOfOrder = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                            }
                            SpecialistDataGridView.Rows.Add(project.ProjectID, project.ProjectName, project.SpecialistID, project.MyStatus, project.ProjectDescription, project.ClientName, project.Location, project.EstimatedHours, project.PricePerHour, priceOfOrder + "€");
                        }
                        else
                        {
                            SpecialistDataGridView.Rows.Add(project.ProjectID, project.ProjectName, project.SpecialistID, project.MyStatus, project.ProjectDescription, project.ClientName, project.Location, project.EstimatedHours, project.PricePerHour, "NONE");
                        }
                        if (project.MyStatus == ProjectStatus.COMPLETED || project.MyStatus == ProjectStatus.FAILED)
                        {
                            DataGridViewCellStyle dataGridViewCellStyle = new();
                            dataGridViewCellStyle.Padding = new Padding(1000, 0, 0, 0);
                            SpecialistDataGridView.Rows[SpecialistDataGridView.Rows.Count - 2].Cells[11].Style = dataGridViewCellStyle;
                            SpecialistDataGridView.Rows[SpecialistDataGridView.Rows.Count - 2].Cells[12].Style = dataGridViewCellStyle;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private void MyProjectsButton_Click(object sender, EventArgs e)
        {
            ShowMyProjects();
        }
        private void NewProjectButton_Click(object sender, EventArgs e)
        {
            SpecialistAddNewProjectForm addNewProjectForm = new(UserID);
            addNewProjectForm.Show();
        }
        private async void AvailablePartsButton_Click(object sender, EventArgs e)
        {
            AddPartsToOrderButton.Visible = false;
            CompleteOrderButton.Visible = false;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087"); 
                HttpResponseMessage response = await httpClient.GetAsync("api/Part/ListAllParts");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<PartModel> parts = JsonConvert.DeserializeObject<List<PartModel>>(json);
                    SpecialistDataGridView.Rows.Clear();
                    SpecialistDataGridView.Columns.Clear();
                    SpecialistDataGridView.Columns.Add("PartName", "Part Name");
                    SpecialistDataGridView.Columns.Add("CurrentPrice", "Current Price (EUR)");
                    SpecialistDataGridView.Columns.Add("NumInStorage", "Number In Storage");
                    SpecialistDataGridView.Columns["PartName"].ReadOnly = true;
                    SpecialistDataGridView.Columns["CurrentPrice"].ReadOnly = true;
                    SpecialistDataGridView.Columns["NumInStorage"].ReadOnly = true;
                    foreach (var part in parts)
                    {
                        if (part.NumInStorage > 0)
                        {
                            SpecialistDataGridView.Rows.Add(part.PartName, part.CurrentPrice + "€", part.NumInStorage);
                        }                      
                    }    
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private void AddPartsToOrderButton_Click(object sender, EventArgs e)
        {
            SpecialistAddOrderEntryToOrderForm newForm = new(OrderID, ProjectID);
            newForm.Show();
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new();
            loginForm.Show();
        }
        private async void SpecialistDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10) // column of "ORDER" button
            {
                ProjectID = Convert.ToInt32(SpecialistDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                ShowOrderEntries();
            }
            if (e.ColumnIndex == 11) // column of "COMPLETED" button
            {
                if (SpecialistDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("INPROGRESS"))
                {
                    ProjectID = Convert.ToInt32(SpecialistDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri("https://localhost:7087");
                        UpdateProjectStatusDto updateProjectStatusDto = new(ProjectID, ProjectStatus.COMPLETED);
                        HttpResponseMessage response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{ProjectID}", updateProjectStatusDto);
                    }
                    ShowMyProjects(); // resetting the data grid view after updating data
                }
                else
                {
                    MessageBox.Show("Error! Only a project with projectStatus INPROGRESS can be completed or failed!");
                }
            }
            if (e.ColumnIndex == 12) // column of "FAILED" button
            {
                if (SpecialistDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() == "INPROGRESS")
                {
                    ProjectID = Convert.ToInt32(SpecialistDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri("https://localhost:7087");
                        UpdateProjectStatusDto updateProjectStatusDto = new(ProjectID, ProjectStatus.FAILED);
                        HttpResponseMessage response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{ProjectID}", updateProjectStatusDto);
                        ShowMyProjects(); // resetting the data grid view after updating data
                    }
                }
                else
                {
                    MessageBox.Show("Only a project with projectStatus INPROGRESS can be completed or failed!");
                }
            }
        }
        private async void ShowOrderEntries()
        {
            string projectStatus = "";
            using (HttpClient httpClient = new())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7087");
                HttpResponseMessage response = await httpClient.GetAsync($"api/Project/GetProjectStatus/{ProjectID}");
                if (response.IsSuccessStatusCode)
                {
                    projectStatus = await response.Content.ReadAsStringAsync();
                }
                if (projectStatus == "0" || projectStatus == "1") // if the project is NEW or DRAFT we can order Parts! once the project is launched this is no longer possible
                {
                    AvailablePartsButton.Visible = true;
                    this.OrderEntriesButton.Visible = true;
                    AddPartsToOrderButton.Visible = true;
                    CompleteOrderButton.Visible = true;
                }
                response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{ProjectID}");
                if (response.IsSuccessStatusCode)
                {
                    OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                }
                if (OrderID == -1) // -1 = there is no order associated with the project
                {
                    response = await httpClient.GetAsync($"api/Order/AddOrderToProject/{ProjectID}");
                    response = await httpClient.GetAsync($"api/Order/GetOrderIdOfProject/{ProjectID}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success! New order addded to the project!");
                        OrderID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                    }
                }
                response = await httpClient.GetAsync($"api/Order/ListOrderEntriesOfOrder/{OrderID}");
                if (response.IsSuccessStatusCode) // clear the projects from the data grid view and list order entries
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Tuple<string, int, int>> orderEntries = JsonConvert.DeserializeObject<List<Tuple<string, int, int>>>(json);
                    SpecialistDataGridView.Rows.Clear();
                    SpecialistDataGridView.Columns.Clear();
                    SpecialistDataGridView.Columns.Add("PartName", "Part Name");
                    SpecialistDataGridView.Columns.Add("PartCount", "Part Count");
                    SpecialistDataGridView.Columns.Add("Status", "Order Status");
                    SpecialistDataGridView.Columns["PartName"].ReadOnly = true;
                    SpecialistDataGridView.Columns["PartCount"].ReadOnly = true;
                    SpecialistDataGridView.Columns["Status"].ReadOnly = true;
                    response = await httpClient.GetAsync($"api/Part/ListAllParts");
                    json = await response.Content.ReadAsStringAsync();
                    List<PartModel> allPossibleParts = JsonConvert.DeserializeObject<List<PartModel>>(json);
                    int lastPartId = -1;
                    bool orderIsReady = true;
                    foreach (var part in orderEntries)
                    {
                        SpecialistDataGridView.Rows.Add(part.Item1, part.Item2, part.Item3 == 0 ? "RESERVED" : "PREORDERED");
                        if (part.Item3 == 1) // if there are any preordered Parts the order is not ready
                            orderIsReady = false;
                    }
                    if (projectStatus == "2" && orderIsReady) // if projectStatus is WAIT and there are no PREORDERED Parts we can start the project
                    {
                        UpdateProjectStatusDto updateProjectStatusDto = new(ProjectID, ProjectStatus.SCHEDULED);
                        response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{ProjectID}", updateProjectStatusDto);
                        MessageBox.Show("No more waiting for preorders! Price calculation completed! Request for order sent!");
                    }
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
        }
        private async void CompleteOrderButton_Click(object sender, EventArgs e)
        {
            bool orderIsReady = true;
            for (int i = 0; i < SpecialistDataGridView.Rows.Count; i++)
            {
                if (SpecialistDataGridView.Rows[i].Cells[2].Value == "PREORDERED") // check if there are any preordered solar panel order entries
                {
                    orderIsReady = false;
                    break;
                }
            }
            if (orderIsReady)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7087");
                    HttpResponseMessage response = await httpClient.PatchAsJsonAsync($"api/Order/CalculatePriceOfOrder/{ProjectID}", OrderID);
                    UpdateProjectStatusDto updateProjectStatusDto = new(ProjectID, ProjectStatus.SCHEDULED);
                    response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{ProjectID}", updateProjectStatusDto);
                }
                MessageBox.Show("Price calculation completed! Request for order sent!");
            }
            else // if there are any preordered parts
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7087");
                    UpdateProjectStatusDto updateProjectStatusDto = new(ProjectID, ProjectStatus.WAIT);
                    HttpResponseMessage response = await httpClient.PatchAsJsonAsync($"api/Project/UpdateProjectStatus/{ProjectID}", updateProjectStatusDto);
                }
                MessageBox.Show("Price Calculation couldn't be completed! Price will be showed after all preordered Parts are supplied!");
            }
            ShowMyProjects(); // going back to show the projects in the data grid view
        }

        private void OrderEntriesButton_Click(object sender, EventArgs e)
        {
            this.AddPartsToOrderButton.Visible = true;
            this.CompleteOrderButton.Visible = true;
            ShowOrderEntries();
        }
    }
}

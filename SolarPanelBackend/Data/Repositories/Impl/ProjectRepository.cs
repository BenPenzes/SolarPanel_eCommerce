using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SolarPanelBackend.Models;
using System.Data;

namespace SolarPanelBackend.Data.Repositories.Impl
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        // Specialist
        // A1
        public int InsertNewProject(ProjectModel project)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.InsertNewProject", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    command.Parameters.AddWithValue("@SpecialistID", project.SpecialistID);
                    command.Parameters.AddWithValue("@ProjectDescription", project.ProjectDescription);
                    command.Parameters.AddWithValue("@ClientName", project.ClientName);
                    command.Parameters.AddWithValue("@ProjectLocation", project.Location);
                    command.Parameters.AddWithValue("@EstimatedHours", project.EstimatedHours);
                    command.Parameters.AddWithValue("@PricePerHour", project.PricePerHour);
                    connection.Open();
                    int projectId = (int)command.ExecuteScalar();
                    Console.WriteLine("Success! Project inserted with ID: " + projectId);
                    return projectId;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // A2
        public ICollection<ProjectModel> ListAllProjectsOfSpecialist(int specialistID)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new("dbo.ListAllProjectsOfSpecialist", connection);
                    command.Parameters.AddWithValue("@PersonID", specialistID);
                    List<ProjectModel> projects = new();
                    command.CommandType = CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string statusStr = reader["ProjectStatus"].ToString();
                        ProjectModel.ProjectStatus status = ProjectModel.ProjectStatus.NEW;
                        switch (statusStr.ToLower())
                        {
                            case "new":
                                status = ProjectModel.ProjectStatus.NEW;
                                break;
                            case "draft":
                                status = ProjectModel.ProjectStatus.DRAFT;
                                break;
                            case "wait":
                                status = ProjectModel.ProjectStatus.WAIT;
                                break;
                            case "scheduled":
                                status = ProjectModel.ProjectStatus.SCHEDULED;
                                break;
                            case "inprogress":
                                status = ProjectModel.ProjectStatus.INPROGRESS;
                                break;
                            case "completed":
                                status = ProjectModel.ProjectStatus.COMPLETED;
                                break;
                            case "failed":
                                status = ProjectModel.ProjectStatus.FAILED;
                                break;
                            default:
                                status = ProjectModel.ProjectStatus.NEW;
                                break;
                        }
                        string projectDescription = reader["ProjectDescription"].Equals(System.DBNull.Value) ? "" : reader["ProjectDescription"].ToString();
                        string clientName = reader["ClientName"].Equals(System.DBNull.Value) ? "" : reader["ClientName"].ToString();
                        string location = reader["ProjectLocation"].Equals(System.DBNull.Value) ? "" : reader["ProjectLocation"].ToString();
                        int estimatedHours = reader["EstimatedHours"].Equals(System.DBNull.Value) ? 0 : (int)reader["EstimatedHours"];
                        decimal pricePerHour = reader["PricePerHour"].Equals(System.DBNull.Value) ? (int)0 : (decimal)reader["PricePerHour"];
                        int intPricePerHour = (int)pricePerHour;
                        var projectModel = new ProjectModel
                        (
                            (int)reader["ProjectID"],
                            reader["ProjectName"].ToString(),
                            (int)status,
                            (int)reader["SpecialistID"],
                            projectDescription,
                            clientName,
                            location,
                            estimatedHours,
                            intPricePerHour
                        );
                        projects.Add(projectModel);
                    }
                    return projects;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // A5, A6
        public int UpdateProjectPricePerHour(int projectID, double newPrice)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.UpdateProjectPricePerHour", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    command.Parameters.AddWithValue("@NewPricePerHour", newPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
                    var rowsAffected = (int)command.ExecuteScalar();
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public int UpdateProjectEstimatedHours(int projectID, int newEstimatedHours)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("UpdateProjectEstimatedHours", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    command.Parameters.AddWithValue("@EstimatedHours", newEstimatedHours);
                    connection.Open();
                    command.ExecuteNonQuery();
                    var rowsAffected = (int)command.ExecuteScalar();
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // Storage Worker
        // C1
        public ICollection<ProjectModel> ListAllProjects()
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new("dbo.ListAllProjects", connection);
                    List<ProjectModel> projects = new();
                    command.CommandType = CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string statusStr = reader["ProjectStatus"].ToString();
                        ProjectModel.ProjectStatus status = ProjectModel.ProjectStatus.NEW;
                        switch (statusStr.ToLower())
                        {
                            case "new":
                                status = ProjectModel.ProjectStatus.NEW;
                                break;
                            case "draft":
                                status = ProjectModel.ProjectStatus.DRAFT;
                                break;
                            case "wait":
                                status = ProjectModel.ProjectStatus.WAIT;
                                break;
                            case "scheduled":
                                status = ProjectModel.ProjectStatus.SCHEDULED;
                                break;
                            case "inprogress":
                                status = ProjectModel.ProjectStatus.INPROGRESS;
                                break;
                            case "completed":
                                status = ProjectModel.ProjectStatus.COMPLETED;
                                break;
                            case "failed":
                                status = ProjectModel.ProjectStatus.FAILED;
                                break;
                            default:
                                status = ProjectModel.ProjectStatus.NEW;
                                break;
                        }
                        string projectDescription = reader["ProjectDescription"].Equals(System.DBNull.Value) ? "" : reader["ProjectDescription"].ToString();
                        string clientName = reader["ClientName"].Equals(System.DBNull.Value) ? "" : reader["ClientName"].ToString();
                        string location = reader["ProjectLocation"].Equals(System.DBNull.Value) ? "" : reader["ProjectLocation"].ToString();
                        int estimatedHours = reader["EstimatedHours"].Equals(System.DBNull.Value) ? 0 : (int)reader["EstimatedHours"];
                        decimal pricePerHour = reader["PricePerHour"].Equals(System.DBNull.Value) ? (int)0 : (decimal)reader["PricePerHour"];
                        int intPricePerHour = (int)pricePerHour;
                        var projectModel = new ProjectModel
                        (
                            (int)reader["ProjectID"],
                            reader["ProjectName"].ToString(),
                            (int)status,
                            (int)reader["SpecialistID"],
                            projectDescription,
                            clientName,
                            location,
                            estimatedHours,
                            intPricePerHour
                        );
                        projects.Add(projectModel);
                    }
                    return projects;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // several requirements: A6, A7, C1, etc.
        public int UpdateProjectStatus(int projectID, ProjectModel.ProjectStatus newStatus)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.UpdateProjectStatus", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    connection.Open();
                    command.ExecuteNonQuery();
                    var rowsAffected = (int)command.ExecuteScalar();
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // helper functions
        public ProjectModel.ProjectStatus GetProjectStatus(int projectID)
        {

            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("GetProjectStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    connection.Open();
                    string projectStatus = (string)command.ExecuteScalar();
                    switch (projectStatus)
                    {
                        case "NEW":
                            return ProjectModel.ProjectStatus.NEW;
                        case "DRAFT":
                            return ProjectModel.ProjectStatus.DRAFT;
                        case "WAIT":
                            return ProjectModel.ProjectStatus.WAIT;
                        case "SCHEDULED":
                            return ProjectModel.ProjectStatus.SCHEDULED;
                        case "INPROGRESS":
                            return ProjectModel.ProjectStatus.INPROGRESS;
                        case "COMPLETED":
                            return ProjectModel.ProjectStatus.COMPLETED;
                        case "FAILED":
                            return ProjectModel.ProjectStatus.FAILED;
                        default:
                            return ProjectModel.ProjectStatus.NEW;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
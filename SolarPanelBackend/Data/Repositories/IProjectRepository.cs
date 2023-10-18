using SolarPanelBackend.Models;
using static SolarPanelBackend.Models.ProjectModel;

namespace SolarPanelBackend.Data.Repositories
{
    public interface IProjectRepository
    {
        // Specialist
        // A1
        public int InsertNewProject(ProjectModel project);
        // A2
        public ICollection<ProjectModel> ListAllProjectsOfSpecialist(int specialistID);
        // A5, A6
        public int UpdateProjectEstimatedHours(int projectID, int newEstimatedHours);
        public int UpdateProjectPricePerHour(int projectID, double newPrice);
        // Storage Worker
        // C1
        public ICollection<ProjectModel> ListAllProjects();
        // several requirements: A6, A7, C1, etc.
        public int UpdateProjectStatus(int projectID, ProjectStatus newStatus);
        // helper functions
        public ProjectStatus GetProjectStatus(int projectID);
    }
}
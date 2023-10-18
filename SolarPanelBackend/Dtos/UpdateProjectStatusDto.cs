using SolarPanelBackend.Models;

namespace SolarPanelBackend.Dtos
{
    public class UpdateProjectStatusDto
    {
        public int ID { get; set; }
        public ProjectModel.ProjectStatus Status { get; set; }
        public UpdateProjectStatusDto(int ID, ProjectModel.ProjectStatus Status)
        {
            this.ID = ID;
            this.Status = Status;
        }
    }
}
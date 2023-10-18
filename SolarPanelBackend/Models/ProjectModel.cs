namespace SolarPanelBackend.Models
{
    public class ProjectModel
    {
        public enum ProjectStatus
        {
            NEW, DRAFT, WAIT, SCHEDULED, INPROGRESS, COMPLETED, FAILED
        }
        public int? ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int SpecialistID { get; set; }
        public ProjectStatus MyStatus { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ClientName { get; set; }
        public string? Location { get; set; }
        public int? EstimatedHours { get; set; }
        public int? PricePerHour { get; set; }
        public ProjectModel() { }
        public ProjectModel(int? ProjectID,
            string ProjectName,
            int Status,
            int SpecialistID,
            string? ProjectDescription,
            string? ClientName,
            string? Location,
            int? EstimatedHours,
            int? PricePerHour
            )
        {
            this.ProjectID = ProjectID;
            this.ProjectName = ProjectName;
            this.SpecialistID = SpecialistID;
            this.MyStatus = (ProjectStatus)Status;
            this.ProjectDescription = ProjectDescription;
            this.ClientName = ClientName;
            this.Location = Location;
            this.EstimatedHours = EstimatedHours;
            this.PricePerHour = PricePerHour;
        }
    }
}
using SolarPanelBackend.Models;

namespace SolarPanelBackend.Dtos
{
    public class UpdateProjectEstimatedHoursDto
    {
        public int ID { get; set; }
        public int EstimatedHours { get; set; }
        public UpdateProjectEstimatedHoursDto(int ID, int EstimatedHours)
        {
            this.ID = ID;
            this.EstimatedHours = EstimatedHours;
        }
    }
}
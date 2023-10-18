namespace SolarPanelBackend.Dtos
{
    public class UpdateCountPerCompartmentDto
    {
        public int ID { get; set; }
        public int CountPerComparment { get; set; }
        public UpdateCountPerCompartmentDto() { }
        public UpdateCountPerCompartmentDto(int ID, int CountPerComparment)
        {
            this.ID = ID;
            this.CountPerComparment = CountPerComparment;
        }
    }
}
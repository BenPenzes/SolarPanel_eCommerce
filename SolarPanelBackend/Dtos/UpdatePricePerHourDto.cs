namespace SolarPanelBackend.Dtos
{
    public class UpdatePricePerHourDto
    {
        public int ID { get; set; }
        public double NewPrice { get; set; }
        public UpdatePricePerHourDto(int ID, double NewPrice)
        {
            this.ID = ID;
            this.NewPrice = NewPrice;
        }
    }
}

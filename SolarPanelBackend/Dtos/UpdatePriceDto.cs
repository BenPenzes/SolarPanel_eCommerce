namespace SolarPanelBackend.Dtos
{
    public class UpdatePriceDto
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public UpdatePriceDto(int ID, decimal Price)
        {
            this.ID = ID;
            this.Price = Price;
        }
    }
}

namespace SolarPanelBackend.Models
{
    public class PartModel
    {
        public int? PartID { get; set; }
        public string PartName { get; set; }
        public string? PartDescription { get; set; }
        public int CountPerCompartment { get; set; }
        public decimal? CurrentPrice { get; set; }
        public int? NumInStorage { get; set; }
        public PartModel(int? PartID, string PartName, string? PartDescription, int CountPerCompartment, decimal? CurrentPrice, int? NumInStorage)
        {
            this.PartID = PartID;
            this.PartName = PartName;
            this.PartDescription = PartDescription;
            this.CountPerCompartment = CountPerCompartment;
            this.CurrentPrice = CurrentPrice;
            this.NumInStorage = NumInStorage;
        }
    }
}

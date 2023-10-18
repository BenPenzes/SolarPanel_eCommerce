namespace SolarPanelBackend.Models
{
    public class OrderEntryModel
    {
        public enum OrderEntryStatus
        {
            RESERVED, PREORDER 
        }
        public int PartID { get; set; }
        public int PartCount { get; set; }
        public OrderEntryStatus MyStatus { get; set;}
        public OrderEntryModel(int partID, int partCount, int myStatus)
        {
            this.PartID = partID;
            this.PartCount = partCount;
            this.MyStatus = (OrderEntryStatus)myStatus;
        }
        public OrderEntryModel() { }
    }
}

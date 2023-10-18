namespace SolarPanelBackend.Models
{
    public class OrderModel
    {
        public enum OrderStatus
        {
            WAITING, FULLFILLED
        }
        public int OrderID { get; set; }
        public OrderStatus MyStatus { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
        public int? StoreKeeperID { get; set; }
        public List<OrderEntryModel>? OrderEntries { get; set; }
        public OrderModel() { }
        public OrderModel(int OrderID, OrderStatus MyStatus, DateTime DateTimeOfOrder, int? StoreKeeperID, List<OrderEntryModel>? OrderEntries)
        {
            this.OrderID = OrderID;
            this.MyStatus = MyStatus;
            this.DateTimeOfOrder = DateTimeOfOrder;
            this.StoreKeeperID = StoreKeeperID;
            this.OrderEntries = OrderEntries;
        }

    }
}

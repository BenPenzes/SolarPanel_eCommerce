using SolarPanelBackend.Models;

namespace SolarPanelBackend.Data.Repositories
{
    public interface IOrderRepository
    {
        // Specialist
        // A4/a
        public int AddOrderToProject(int projectID);
        // A4/b
        public int AddOrderEntryToOrder(int orderID, OrderEntryModel orderEntry);
        // A5, A6
        public int CalculatePriceOfOrder(int OrderID, int ProjectID);
        // helper functions
        public int GetOrderIdOfProject(int projectId);
        public ICollection<Tuple<string, int, int>> ListOrderEntriesOfOrder(int orderID);
    }
}

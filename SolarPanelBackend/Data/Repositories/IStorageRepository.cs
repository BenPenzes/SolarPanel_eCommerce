using SolarPanelBackend.Models;

namespace SolarPanelBackend.Data.Repositories
{
    public interface IStorageRepository
    {
        // Storage Manager
        // B5, B6
        public int SupplyParts(int partID, int numOfParts);
        // Storage Worker
        // C1
        public int FulfillOrder(int orderID);
        // C2
        public ICollection<Tuple<List<int>, string>> ListPartsOfOrderInStorage(int orderID);
        // C3
        public ICollection<Tuple<string, List<int>>> ShortestPath(int orderID);
        // not required functions
        public ICollection<Tuple<List<int>, string>> ViewStorage();
    }
}

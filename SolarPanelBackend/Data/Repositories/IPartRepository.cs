using SolarPanelBackend.Models;

namespace SolarPanelBackend.Data.Repositories
{
    public interface IPartRepository
    {
        // Specialist
        // A2
        public ICollection<PartModel> ListAllPartsAndInventory();
        // Storage Manager
        // B1
        public int InsertNewPart(PartModel part);
        // B2
        public int UpdatePartPrice(int partId, decimal newPrice);
        // B3
        public ICollection<Tuple<string, string, int>> ListAllPartsPreordered();
        // B4
        public ICollection<PartModel> ListAllPartsNotInStorage();
        // not required functions
        public int UpdatePartCountPerCompartment(int partId, int newCountPerCompartment);
    }
}

using Inventory_Tracker_Project.Models;

namespace Inventory_Tracker_Project.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<MetaZooItem>> GetAsync();

        Task InsertItemAsync(MetaZooItem item);
    }
}
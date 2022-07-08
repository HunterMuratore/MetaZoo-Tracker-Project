using Inventory_Tracker_Project.Models;

namespace Inventory_Tracker_Project.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<MetaZooItem>> GetAsync();

        void InsertItem(MetaZooItem item);
    }
}
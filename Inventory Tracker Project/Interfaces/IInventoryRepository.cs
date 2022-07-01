using Inventory_Tracker_Project.Models;

namespace Inventory_Tracker_Project.Interfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<MetaZooItem> Get();

        void InsertItem(MetaZooItem item);
    }
}
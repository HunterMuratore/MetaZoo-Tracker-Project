using Inventory_Tracker_Project.Models.Catalog;

namespace Inventory_Tracker_Project.Interfaces.Repositories
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogItem>> GetAsync();

        Task InsertItemAsync(CatalogItem item);
    }
}
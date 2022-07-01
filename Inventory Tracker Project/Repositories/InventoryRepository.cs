using Inventory_Tracker_Project.Interfaces;
using Inventory_Tracker_Project.Models;
using MongoDB.Driver;

namespace Inventory_Tracker_Project.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMongoCollection<MetaZooItem> _collection;

        public InventoryRepository(IMongoDatabase mongo)
        {
            _collection = mongo.GetCollection<MetaZooItem>("items");
        }

        /// <summary>
        /// Gets all MetaZoo items in the database
        /// </summary>
        /// <returns>A collection of MetaZoo items</returns>
        public IEnumerable<MetaZooItem> Get()
        {
            return _collection.AsQueryable();
        }

        public void InsertItem(MetaZooItem item)
        {
            _collection.InsertOne(item);
        }
    }
}
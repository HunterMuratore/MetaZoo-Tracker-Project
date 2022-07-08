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
        /// <returns>A task with result being a collection of MetaZoo items</returns>
        public async Task<IEnumerable<MetaZooItem>> GetAsync()
        {
            var queryResult = await _collection.FindAsync<MetaZooItem>(FilterDefinition<MetaZooItem>.Empty);

            return queryResult.Current;
        }

        public void InsertItem(MetaZooItem item)
        {
            _collection.InsertOne(item);
        }
    }
}
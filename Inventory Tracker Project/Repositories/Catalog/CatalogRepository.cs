using Inventory_Tracker_Project.Interfaces.Repositories;
using Inventory_Tracker_Project.Models.Catalog;
using MongoDB.Driver;

namespace Inventory_Tracker_Project.Repositories.Catalog
{
    public class CatalogRepository : ICatalogRepository
    {
        private const string COLLECTION_NAME = "Catalog";

        private readonly IMongoCollection<CatalogItem> _collection;

        public CatalogRepository(IMongoDatabase mongo)
        {
            _collection = mongo.GetCollection<CatalogItem>(COLLECTION_NAME);
        }

        public async Task<IEnumerable<CatalogItem>> GetAsync()
        {
            var queryResult = await _collection.FindAsync<CatalogItem>(FilterDefinition<CatalogItem>.Empty);
            return queryResult.ToEnumerable();
        }

        public Task InsertItemAsync(CatalogItem item)
        {
            return _collection.InsertOneAsync(item);
        }
    }
}
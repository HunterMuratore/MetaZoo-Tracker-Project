using Inventory_Tracker_Project.Enums.Catalog;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Tracker_Project.Models.Catalog
{
    [BsonIgnoreExtraElements]
    public class CatalogItem
    {
        public CatalogItem(CatalogItemType type, string name, string edition, DateTime releaseDate, int printRun, BsonObjectId? id = default)
        {
            Type = type;
            Name = name;
            Edition = edition;
            ReleaseDate = releaseDate;
            PrintRun = printRun;
            Id = id == default ? new BsonObjectId(ObjectId.GenerateNewId()) : id;
        }

        public CatalogItemType Type { get; }
        public string Name { get; }
        public string Edition { get; }
        public DateTime ReleaseDate { get; }
        public int PrintRun { get; }
        [BsonId]
        public BsonObjectId Id { get; }
    }
}
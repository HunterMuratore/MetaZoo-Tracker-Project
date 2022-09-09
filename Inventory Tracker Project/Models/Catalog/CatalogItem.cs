using Inventory_Tracker_Project.Enums.Catalog;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Tracker_Project.Models.Catalog
{
    public class CatalogItem
    {
        public CatalogItem(CatalogItemType type, string name, string edition, DateTime releaseDate, int printRun, Guid id = default)
        {
            Type = type;
            Name = name;
            Edition = edition;
            ReleaseDate = releaseDate;
            PrintRun = printRun;
            Id = id == default ? Guid.NewGuid() : id;
        }

        [BsonId]
        public Guid Id { get; }
        public CatalogItemType Type { get; }
        public string Name { get; }
        public string Edition { get; }
        public DateTime ReleaseDate { get; }
        public int PrintRun { get; }
    }
}
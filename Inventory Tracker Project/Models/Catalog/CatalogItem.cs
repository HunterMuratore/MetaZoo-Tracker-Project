using Inventory_Tracker_Project.Enums.Catalog;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Tracker_Project.Models.Catalog
{
    [BsonIgnoreExtraElements]
    public class CatalogItem
    {
        public CatalogItem(CatalogItemType type, string set,string name, string edition, DateTime releaseDate, int printRun)
        {
            Type = type;
            Set = set;
            Name = name;
            Edition = edition;
            ReleaseDate = releaseDate;
            PrintRun = printRun;
        }

        public CatalogItemType Type { get; }
        public string Set { get; }
        public string Name { get; }
        public string Edition { get; }
        public DateTime ReleaseDate { get; }
        public int PrintRun { get; }
    }
}
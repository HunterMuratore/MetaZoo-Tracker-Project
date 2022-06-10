using Inventory_Tracker_Project.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Tracker_Project.Models
{
    [BsonIgnoreExtraElements]
    public class MetaZooItem
    {
        public MetaZooItem(MetaZooItemType type, string name, string edition, DateTime releaseDate, int printRun)
        {
            Type = type;
            Name = name;
            Edition = edition;
            ReleaseDate = releaseDate;
            PrintRun = printRun;
        }

        public MetaZooItemType Type { get; }
        public string Name { get; }
        public string Edition { get; }
        public DateTime ReleaseDate { get; }
        public int PrintRun { get; }       
    }
}

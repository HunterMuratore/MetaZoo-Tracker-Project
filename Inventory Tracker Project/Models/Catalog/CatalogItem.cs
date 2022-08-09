using Inventory_Tracker_Project.Enums.Catalog;

namespace Inventory_Tracker_Project.Models.Catalog
{
    public class CatalogItem
    {
        public CatalogItem(CatalogItemType type, string name, string edition, DateTime releaseDate, int printRun)
        {
            Type = type;
            Name = name;
            Edition = edition;
            ReleaseDate = releaseDate;
            PrintRun = printRun;
        }

        public CatalogItemType Type { get; }
        public string Name { get; }
        public string Edition { get; }
        public DateTime ReleaseDate { get; }
        public int PrintRun { get; }
    }
}
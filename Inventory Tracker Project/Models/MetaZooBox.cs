namespace Inventory_Tracker_Project.Models
{
    public class MetaZooBox
    {
        public MetaZooBox(string name, string edition, DateTime releaseDate, int printRun)
        {
            Name = name;
            Edition = edition;
            ReleaseDate = releaseDate;
            PrintRun = printRun;
        }

        public string Name { get; }
        public string Edition { get; }
        public DateTime ReleaseDate { get; }
        public int PrintRun { get; }       
    }
}

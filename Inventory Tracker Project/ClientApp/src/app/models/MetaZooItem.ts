namespace Inventory_Tracker_Project.ClientApp.src.app.models
{
  export interface MetaZooItem {
    type: '../enums/MetaZooItemType.ts';
    name: string;
    edition: number;
    releaseDate: Date;
    printRun: number;
  }
}

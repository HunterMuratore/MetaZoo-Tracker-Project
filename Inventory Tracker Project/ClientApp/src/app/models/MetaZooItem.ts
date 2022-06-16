import { MetaZooItemType } from "../enums/MetaZooItemType";

namespace Inventory_Tracker_Project.ClientApp.src.app.models
{
  export interface MetaZooItem {
    type: MetaZooItemType;
    name: string;
    edition: number;
    releaseDate: Date;
    printRun: number;
  }
}

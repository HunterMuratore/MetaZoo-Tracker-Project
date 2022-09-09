import { MetaZooItemType } from "../enums/MetaZooItemType";

export interface MetaZooItem {
  type: MetaZooItemType;
  name: string;
  edition: string;
  releaseDate: Date;
  printRun: number;
  id: string;
}
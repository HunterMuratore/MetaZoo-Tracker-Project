import { MetaZooItemType } from "../enums/MetaZooItemType";

export interface MetaZooItem {
  type: MetaZooItemType;
  name: string;
  edition: number;
  releaseDate: Date;
  printRun: number;
}


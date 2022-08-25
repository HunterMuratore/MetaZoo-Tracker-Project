import { MetaZooItemType } from "../enums/MetaZooItemType";
import { ObjectId } from 'bson';

export interface MetaZooItem {
  type: MetaZooItemType;
  name: string;
  edition: string;
  releaseDate: Date;
  printRun: number;
  id: ObjectId
}


import { MetaZooItemType } from "./MetaZooItemType";

export function MetaZooItemTypeAware(constructor: Function) {
  constructor.prototype.MetaZooItemType = MetaZooItemType;
}

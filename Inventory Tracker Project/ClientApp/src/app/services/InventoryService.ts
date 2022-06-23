import { Injectable } from "@angular/core";
import { MetaZooItem } from "../models/MetaZooItem";

@Injectable()
export class InventoryService {
  private inventory: string[] = [];

  constructor(
    private backend: ['../Controllers/InventoryController']) { }

  getItems() {
    return this.http.get<MetaZooItem>(this.inventory);
  }

  addItem() {

  }
}

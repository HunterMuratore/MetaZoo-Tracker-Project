import { Component, OnInit } from '@angular/core';
import { MetaZooItem } from '../models/MetaZooItem';
import { InventoryService } from '../services/InventoryService';

@Component({
  selector: 'app-page',
  templateUrl: './InventoryComponent.html',
  styleUrls: ['./InventoryComponent.css']
})
export class InventoryComponent implements OnInit {
  items: MetaZooItem[];
  columnsToDisplay = ['itemType', 'itemName', 'itemEdition', 'itemReleaseDate', 'itemPrintRun'];

  isMetaZooItemTypeCase(): boolean {
    return this.items == this.items.Box;
  } 

  constructor(private inventoryService: InventoryService) {
    this.items = [];
  }

  ngOnInit(): void {
    this.inventoryService.getItems().subscribe((items) => {
      this.items = items;
    });
  }
}

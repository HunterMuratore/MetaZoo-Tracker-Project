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
  columnsToDisplay = ['itemName', 'itemEdition', 'itemReleaseDate', 'itemPrintRun'];

  constructor(private inventoryService: InventoryService) {
    this.items = [];
  }

  ngOnInit(): void {
    this.inventoryService.getItems().subscribe((items) => {
      this.items = items;
    });
  }

  addItem() {
    alert("You pressed the button")
  }
}

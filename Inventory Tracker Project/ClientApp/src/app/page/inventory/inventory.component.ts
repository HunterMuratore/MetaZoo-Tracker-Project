import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MetaZooItem } from '../../models/MetaZooItem';
import { InventoryService } from '../../services/InventoryService';
import { AddItemComponent } from './add-item/add-item.component';

@Component({
  selector: 'app-page',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  items: MetaZooItem[];
  columnsToDisplay = ['itemName', 'itemEdition', 'itemReleaseDate', 'itemPrintRun'];

  constructor(private inventoryService: InventoryService, private dialogRef: MatDialog) {
    this.items = [];
  }

  ngOnInit(): void {
    this.inventoryService.getItems().subscribe((items) => {
      this.items = items;
    });
  }

  addItem() {
    this.dialogRef.open(AddItemComponent);
  }
}

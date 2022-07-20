import { Component, OnInit, ViewChild } from '@angular/core';
import { MetaZooItem } from '../models/MetaZooItem';
import { InventoryService } from '../services/InventoryService';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-page',
  templateUrl: './InventoryComponent.html',
  styleUrls: ['./InventoryComponent.css']
})
export class InventoryComponent implements OnInit {
  items: MetaZooItem[];
  columnsToDisplay = ['itemName', 'itemEdition', 'itemReleaseDate', 'itemPrintRun'];

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private inventoryService: InventoryService) {
    this.items = [];
  }

  ngOnInit(): void {
    this.inventoryService.getItems().subscribe((items) => {
      this.items = items;
      this.items.sort = this.sort;
      this.items.paginator = this.paginator;
    });
  }
}

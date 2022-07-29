import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MetaZooItem } from '../models/MetaZooItem';
import { InventoryService } from '../services/InventoryService';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-page',
  templateUrl: './InventoryComponent.html',
  styleUrls: ['./InventoryComponent.css']
})
export class InventoryComponent implements OnInit, AfterViewInit {
  items: MatTableDataSource<MetaZooItem>;
  columnsToDisplay = ['itemName', 'itemEdition', 'itemReleaseDate', 'itemPrintRun'];

  @ViewChild(MatSort) sort: MatSort = new MatSort();
  // @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private inventoryService: InventoryService) {
    this.items = new MatTableDataSource();
  }

  ngAfterViewInit() {
    this.items.sort = this.sort;
    // this.items.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.inventoryService.getItems().subscribe((items) => {
      this.items = new MatTableDataSource(items);
    });
  }
}

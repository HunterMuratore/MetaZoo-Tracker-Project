import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MetaZooItem } from '../models/MetaZooItem';
import { InventoryService } from '../services/InventoryService';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-page',
  templateUrl: './InventoryComponent.html',
  styleUrls: ['./InventoryComponent.css']
})
export class InventoryComponent implements OnInit, AfterViewInit {
  dataSource: MatTableDataSource<MetaZooItem> = new MatTableDataSource();
  columnsToDisplay = ['name', 'edition', 'releaseDate', 'printRun'];

  @ViewChild(MatSort) sort: MatSort = new MatSort();

  constructor(private inventoryService: InventoryService) { }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.inventoryService.getItems().subscribe((items) => {
      this.dataSource.data = items;
    });
  }
}

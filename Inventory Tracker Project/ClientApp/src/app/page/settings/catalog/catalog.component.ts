import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MetaZooItem } from '../../../models/MetaZooItem';
import { CatalogService } from '../../../services/CatalogService';
import { AddItemComponent } from './add-item/add-item.component';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})

export class CatalogComponent implements OnInit, AfterViewInit {
  dataSource: MatTableDataSource<MetaZooItem> = new MatTableDataSource();
  columnsToDisplay = ['set', 'name', 'edition', 'releaseDate', 'printRun'];

  @ViewChild(MatSort) sort: MatSort = new MatSort();

  constructor(private catalogService: CatalogService, private dialogRef: MatDialog) {  }

  ngOnInit(): void {
    this.catalogService.getItems().subscribe((items) => {
      this.dataSource.data = items;
    });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  addItem() {
    this.dialogRef.open(AddItemComponent);
  }
}

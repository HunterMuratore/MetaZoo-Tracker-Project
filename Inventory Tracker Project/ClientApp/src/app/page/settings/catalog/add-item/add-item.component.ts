import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MetaZooItem } from '../../../../models/MetaZooItem';
import { CatalogService } from '../../../../services/CatalogService';


@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {  

  constructor(private catalogService: CatalogService, private dialogRef: MatDialogRef<AddItemComponent>) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    form.value.type = parseInt(form.value.type);
    if (form.value.printRun == '') {
      form.value.printRun = 0;
    } else {
      form.value.printRun = parseInt(form.value.printRun);
    }
    var formValues = form.value as MetaZooItem;
    this.catalogService.addItem(formValues).subscribe();
    form.reset();
    window.location.reload();
  }
}

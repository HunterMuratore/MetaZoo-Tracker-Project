import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MetaZooItem } from '../../../../models/MetaZooItem';
import { CatalogService } from '../../../../services/CatalogService';


@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {  

  constructor( private catalogService: CatalogService ) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    form.value.type = parseInt(form.value.type);
    form.value.printRun = parseInt(form.value.printRun);
    var formValues = form.value as MetaZooItem;
    this.catalogService.addItem(formValues).subscribe();
  }

  onClose() {

  }
}

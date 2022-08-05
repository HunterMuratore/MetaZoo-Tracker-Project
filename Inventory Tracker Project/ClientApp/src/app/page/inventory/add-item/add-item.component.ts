import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { InventoryService } from '../../../services/InventoryService';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {

  constructor( private inventoryService: InventoryService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    alert(form.value);
    /*this.inventoryService.addItem().subscribe((form) => {
      this. = form;
    })*/
  }

  onClose() {

  }
}

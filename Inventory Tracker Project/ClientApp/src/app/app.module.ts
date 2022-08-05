import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { InventoryComponent } from './page/inventory/inventory.component';
import { InventoryService } from './services/InventoryService';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { AddItemComponent } from './page/inventory/add-item/add-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    InventoryComponent,
    AddItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatDialogModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'Inventory', component: InventoryComponent}
    ])
  ],
  providers: [
    InventoryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

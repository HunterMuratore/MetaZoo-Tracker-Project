import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CatalogService } from './services/CatalogService';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog'
import { SettingsComponent } from './page/settings/settings.component';
import { MatTabsModule } from '@angular/material/tabs';
import { CatalogComponent } from './page/settings/catalog/catalog.component';
import { InventoryComponent } from './page/inventory/inventory.component';
import { AddItemComponent } from './page/inventory/add-item/add-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SettingsComponent,
    CatalogComponent,
    AddItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatSortModule,
    MatDialogModule,
    MatTabsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'Inventory', component: InventoryComponent },
      { path: 'Settings', component: SettingsComponent }
    ])
  ],
  providers: [
    CatalogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { MetaZooItem } from "../models/MetaZooItem";
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Inject } from "@angular/core";
import { Observable } from "rxjs";

export class InventoryService {

  controllerUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.controllerUrl = baseUrl + 'Inventory';
  }

  getItems() : Observable<MetaZooItem[]> {
    return this.http.get<MetaZooItem[]>(this.controllerUrl);
  }

  addItem(item: MetaZooItem) : Observable<HttpResponse<Object>> {
    return this.http.post(this.controllerUrl, item, { responseType: "json", observe: "response" });
  }
}

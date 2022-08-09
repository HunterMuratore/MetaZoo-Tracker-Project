import { MetaZooItem } from "../models/MetaZooItem";
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})

export class CatalogService {
  controllerUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.controllerUrl = baseUrl + 'api/Catalog';
  }

  getItems(): Observable<MetaZooItem[]> {
    return this.http.get<MetaZooItem[]>(this.controllerUrl);
  }

  addItem(item: MetaZooItem): Observable<HttpResponse<Object>> {
    return this.http.post(this.controllerUrl, item, { responseType: "json", observe: "response" });
  }
}

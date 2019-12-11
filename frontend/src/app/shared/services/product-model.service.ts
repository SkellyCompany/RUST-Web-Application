import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ProductModel } from '../models/productModel.model';
import { FilteredList } from '../models/filteredList.model';


@Injectable({ providedIn: 'root' })
export class ProductModelService {
  private apiUrl = 'http://localhost:55390/api/productmodels';

  constructor(private http: HttpClient) { }

  /* GET all productModels */
  getProductModels(currentPage: number, itemsPerPage: number, categoryType: string): Observable<FilteredList<ProductModel>> {
    const params = new HttpParams()
    .set('currentPage', currentPage.toString())
    .set('itemsPerPage', itemsPerPage.toString())
    .set('categoryType', categoryType.toString())
    return this.http.get<FilteredList<ProductModel>>(this.apiUrl, {params: params});
  }

}
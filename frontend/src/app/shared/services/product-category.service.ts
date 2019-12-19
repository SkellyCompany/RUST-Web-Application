import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {ProductCategory} from '../models/product/productCategory.model';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {

  constructor(private http: HttpClient) { }

  /* GET all product categories */
  getProductCategories(): Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(environment.apiUrl + '/api/productcategories');
  }
}

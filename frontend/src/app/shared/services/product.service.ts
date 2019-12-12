import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Product } from '../models/product/product.model';


@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = 'http://localhost:49468/api/products';


  constructor(private http: HttpClient) { }

  /* GET all products */
  getProducts(): Observable<Product> {
    return this.http.get<Product>(this.apiUrl);
  }

}
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Product } from '../models/product/product.model';
import { AuthenticationService } from './authentication.service';


@Injectable({ providedIn: 'root' })
export class ProductService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  /* GET all products */
  getProducts(): Observable<Product> {
    return this.http.get<Product>(environment.apiUrl + '/api/products');
  }

}
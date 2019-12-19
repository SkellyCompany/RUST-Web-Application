import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {ProductMetric} from '../models/product/productMetric.model';

@Injectable({
  providedIn: 'root'
})
export class ProductMetricService {

  constructor(private http: HttpClient) { }

  /* GET all product metrics */
  getProductMetrics(): Observable<ProductMetric[]> {
    return this.http.get<ProductMetric[]>(environment.apiUrl + '/api/productmetrics');
  }
}

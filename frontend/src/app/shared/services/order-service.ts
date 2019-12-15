import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Order } from '../models/order/order.model';


@Injectable({ providedIn: 'root' })
export class OrderService {

  constructor(private http: HttpClient) { }

  /* POST order */
  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(environment.apiUrl + '/api/orders', order);
  }

}
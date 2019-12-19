import { Component, OnInit } from '@angular/core';
import {Order} from '../../shared/models/order/order.model';
import {OrderService} from '../../shared/services/order-service';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.scss']
})
export class AdminOrdersComponent implements OnInit {

  title = 'Orders';
  orders: Order[];

  constructor(private orderService : OrderService) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getOrders().
    subscribe(orders => this.orders = orders);
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-navigation-bar',
  templateUrl: './admin-navigation-bar.component.html',
  styleUrls: ['./admin-navigation-bar.component.scss']
})
export class AdminNavigationBarComponent implements OnInit {

  readonly PRODUCTS_SUBMENU = 'PRODUCTS';
  readonly ORDERS_SUBMENU = 'ORDERS';

  submenu = '';

  constructor() { }

  ngOnInit() {
  }

  setSubmenu(submenu: string) {
    this.submenu = submenu;
  }

}

import { Component, OnInit, Input } from '@angular/core';
import { ProductCart } from '../models/productCart';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {

  isCartVisible: boolean = false;
  productCarts: ProductCart[] = [];

  constructor() {
   }

  ngOnInit() {
  }

  addProductToCart(productCart: ProductCart){
    this.productCarts.push(productCart);
  }

  setProductCartQuantity(number: number){
    if (number > 0){
      if (this.productCarts[0].quantity < 10){
        this.productCarts[0].quantity += number;
      }
    }
    else  if (number < 0){
      if (this.productCarts[0].quantity = 1){
        event.stopPropagation();
        this.productCarts.splice(0, 1);
      }
    }
  }

  getSubtotal(){
    let subtotal: number = 0;
    for (var i = 0; i < this.productCarts.length; i++) {
      if (this.productCarts[i] == this.productCarts[0]){
        subtotal += this.productCarts[i].price;
      }
      else{
        subtotal += this.productCarts[i].price + 0.01;
      }
    }
    return subtotal.toFixed(2);
  }

  setCartVisibility(){
    if (this.isCartVisible){
      this.isCartVisible = false;
    }
    else{
      event.stopPropagation();
      this.isCartVisible = true;
    }
  }
}
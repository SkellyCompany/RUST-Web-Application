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
    console.log(productCart.name);
    this.productCarts.push(productCart);
  }

  setSubtotal(){
    let subtotal;
    for (var i = 0; i < this.productCarts.length; i++) {
      subtotal = this.productCarts[i].price;
    }
    console.log(subtotal);
    return subtotal;
  }

  setProductCartQuantity(number: number){
    if (number > 0){
      if (this.productCarts[0].quantity < 10){
        this.productCarts[0].quantity += number;
      }
    }
    else  if (number < 0){
      if (this.productCarts[0].quantity = 1){
        this.productCarts.splice(0, 1);
      }
    }
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
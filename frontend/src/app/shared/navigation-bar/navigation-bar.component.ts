import { Component, OnInit, Input } from '@angular/core';
import { ProductCart } from '../models/productCart';
import { CartService } from '../services/cart-service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {

  isCartVisible: boolean = false;
  productCarts: ProductCart[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit() {
  }

  addProductToCart(productCart: ProductCart){
    this.cartService.addProductCart(productCart);
    this.productCarts = this.cartService.getProductCarts();
  }

  setProductCartQuantity(index: number, value: number){
    if (value > 0){
      if (this.productCarts[index].quantity < 10){
        this.productCarts[index].quantity += value;
        this.cartService.updateProductCart(this.productCarts);
      }
    }
    else  if (value < 0){
      if (this.productCarts[index].quantity == 1){
        event.stopPropagation();
        this.cartService.removeProductCart(index);
        this.productCarts = this.cartService.getProductCarts();
      }
      else{
        this.productCarts[index].quantity += value;
        this.cartService.updateProductCart(this.productCarts);
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
      this.productCarts = this.cartService.getProductCarts();
      this.isCartVisible = true;
    }
  }

  counter(i: number) {
    return new Array(i);
  }
}
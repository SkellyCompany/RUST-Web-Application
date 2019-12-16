import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductCart } from '../models/productCart';


@Injectable({ providedIn: 'root' })
export class CartService {

  productCarts: ProductCart[] = [];

  constructor(private http: HttpClient) {}

  addProductCart(productCart: ProductCart){
    if (this.getProductCarts() != null){
      this.productCarts = this.getProductCarts();
    }
    this.productCarts.push(productCart);
    localStorage.setItem('productCarts', JSON.stringify(this.productCarts));
  }

  removeProductCart(index: number){
    this.productCarts.splice(index, 1);
    let storedProductCarts = this.getProductCarts();
    storedProductCarts = this.productCarts;
    localStorage.setItem('productCarts', JSON.stringify(storedProductCarts));
  }

  removeAllProductCart(){
    this.productCarts = [];
    localStorage.removeItem('productCarts')
  }

  updateProductCart(productCarts: ProductCart[]){
    let storedProductCarts = this.getProductCarts();
    storedProductCarts = productCarts;
    localStorage.setItem('productCarts', JSON.stringify(storedProductCarts));
  }

  getProductCarts(): ProductCart[]{
    let productCarts = JSON.parse(localStorage.getItem('productCarts'));
    return productCarts;
  }
}
import { Component, OnInit } from '@angular/core';
import { ProductCart } from 'src/app/shared/models/productCart';
import { CartService } from 'src/app/shared/services/cart-service';
import { CountryService } from 'src/app/shared/services/country.service';
import { Country } from 'src/app/shared/models/order/country.model';
import { FormGroup, FormControl } from '@angular/forms';
import { OrderService } from 'src/app/shared/services/order-service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  isOrderConfirmationVisible : boolean;
  productCarts: ProductCart[] = [];
  countries: Country[] = [];
  orderForm = new FormGroup({
    orderDate: new FormControl(''),
    deliveryDate: new FormControl(''),
    address: new FormControl(''),
    city: new FormControl(''),
    zipCode: new FormControl(''),
    country: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    emai: new FormControl(''),
    phone: new FormControl('')
  });

  constructor(private cartService: CartService, private countryService: CountryService, private orderService: OrderService) { }

  ngOnInit() {
    this.productCarts = this.cartService.getProductCarts();
    this.getCountries();
  }

  setOrderConfirmationVisibility(){
    if (this.isOrderConfirmationVisible){
      this.isOrderConfirmationVisible = false;
    }
    else{
      event.stopPropagation();
      this.isOrderConfirmationVisible = true;
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

  getCountries(){
    this.countryService.getCountries()
    .subscribe(countries => this.countries = this.countries.concat(countries));
  }

  addOrder(){
    const orderFromFields = this.orderForm.value;
    console.log(orderFromFields.firstName);
    // this.orderService.addOrder(orderFromFields)
    // .subscribe(order => console.log(order.firstName, order.lastname));
  }
}
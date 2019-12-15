import { Component, OnInit } from '@angular/core';
import { ProductCart } from 'src/app/shared/models/productCart';
import { CartService } from 'src/app/shared/services/cart-service';
import { CountryService } from 'src/app/shared/services/country.service';
import { Country } from 'src/app/shared/models/order/country.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { OrderService } from 'src/app/shared/services/order-service';
import { OrderLine } from 'src/app/shared/models/order/orderLine.model';
import { Order } from 'src/app/shared/models/order/order.model';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  isOrderConfirmationVisible : boolean;
  isErrorValidationVisible: boolean;
  productCarts: ProductCart[] = [];
  countries: Country[] = [];
  currentCountry: Country;
  orderForm = new FormGroup({
    orderDate: new FormControl(''),
    deliveryDate: new FormControl(''),
    orderLines: new FormControl(''),
    address: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    zipCode: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    phone: new FormControl('', Validators.required)
  });

  constructor(private cartService: CartService, private countryService: CountryService, private orderService: OrderService) { }

  ngOnInit() {
    this.productCarts = this.cartService.getProductCarts();
    this.getCountries();
  }

  setOrderConfirmationVisibility(){
    if (this.isOrderConfirmationVisible){
      this.isOrderConfirmationVisible = false;
      this.cartService.removeAllProductCart();
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

  setCurrentCountry(country: Country){
    this.currentCountry = country;
  }

  addOrder(){
    this.isErrorValidationVisible = true;

    const orderFromFields = this.orderForm.value;
    const today = new Date()
    const orderLines: OrderLine[] = [];
    for (var i = 0; i < this.productCarts.length; i++) {
      var orderLine: OrderLine = {order: null, productStock: this.productCarts[i].productStock, quantity: this.productCarts[i].quantity};
      orderLines.push(orderLine);
    }

    const order = {
      orderDate: today,
      deliveryDate: new Date(today.getFullYear(), today.getMonth(), today.getDate() + 2, today.getHours(), today.getMinutes(), today.getSeconds(), 0),
      orderLines: orderLines,
      address: orderFromFields.address,
      city: orderFromFields.city,
      zipCode: orderFromFields.zipCode,
      country: this.currentCountry,
      firstName: orderFromFields.firstName,
      lastName: orderFromFields.lastName,
      email: orderFromFields.email,
      phone: orderFromFields.phone
    }

    this.orderService.addOrder(order as Order)
    .subscribe(
    result => {
      this.setOrderConfirmationVisibility()
    },
    error => {
      window.scrollTo(0, 0)
      }
    )
  }
}
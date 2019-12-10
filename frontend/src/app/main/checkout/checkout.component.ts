import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  isOrderConfirmationVisible : boolean;

  constructor() { }

  ngOnInit() {
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

}
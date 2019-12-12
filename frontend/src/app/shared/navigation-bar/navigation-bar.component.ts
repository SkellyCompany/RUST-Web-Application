import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {

  @Input() isCartVisible: boolean = false;

  constructor() {
   }

  ngOnInit() {
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
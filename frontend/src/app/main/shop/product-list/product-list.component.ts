import { Component, OnInit } from '@angular/core';
import { ProductModel } from 'src/app/shared/models/productModel.model';
import { ProductModelService } from 'src/app/shared/services/product-model.service';
import { Router, NavigationEnd } from '@angular/router';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  productModels: ProductModel[];
  totalPages: number;
  categoryType: string = "Default";
  currentPage: number = 1;
  itemsPerPage: number = 6;

  constructor(private productModelService: ProductModelService, private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = function(){
      return false; 
  }

    this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
        this.router.navigated = false;
        window.scrollTo(0, 0);
      }
    });
  }

  ngOnInit() {
    this.getProductModels(this.currentPage, this.categoryType);
  }

  getProductModels(currentPage: number, categoryType: string): void{
    this.currentPage = currentPage;
    this.categoryType = categoryType;
    this.productModelService.getProductModels(currentPage, this.itemsPerPage, categoryType)
    .subscribe(filteredList => {this.productModels = filteredList.data; this.totalPages = filteredList.totalPages;});
  }

  counter(i: number) {
    return new Array(i);
  }
}

import { Component, OnInit } from '@angular/core';
import {ProductCategoryService} from '../../shared/services/product-category.service';
import {ProductCategory} from '../../shared/models/product/productCategory.model';

@Component({
  selector: 'app-admin-categories',
  templateUrl: './admin-categories.component.html',
  styleUrls: ['./admin-categories.component.scss']
})
export class AdminCategoriesComponent implements OnInit {

  title = 'Categories';
  productCategories: ProductCategory[];

  constructor(private productCategoryService : ProductCategoryService) { }

  ngOnInit() {
    this.getProductCategories();
  }

  getProductCategories(): void {
    this.productCategoryService.getProductCategories().
    subscribe(productCategories => this.productCategories = productCategories);
  }

}

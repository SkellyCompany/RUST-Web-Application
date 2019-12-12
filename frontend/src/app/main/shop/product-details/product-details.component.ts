import { Component, OnInit, ɵConsole, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/shared/services/product.service';
import { Product } from 'src/app/shared/models/product/product.model';
import { ProductModelService } from 'src/app/shared/services/product-model.service';
import { ProductModel } from 'src/app/shared/models/product/productModel.model';
import { NavigationBarComponent } from 'src/app/shared/navigation-bar/navigation-bar.component';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {

  @ViewChild(NavigationBarComponent, {static: false}) child:NavigationBarComponent;
  products: Product[] = [];
  currentProduct: Product;
  currentProductStockIndex: number;
  productModel: ProductModel;

  constructor(private productService: ProductService, private productModelService: ProductModelService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getProductModel();
    this.getProduct();
    this.getProducts();
  }


  getProductModel(): void{
    const id = +this.route.snapshot.paramMap.get('id');
    this.productModelService.getProductModel(id)
    .subscribe(productModel => this.productModel = productModel)
  }

  getProduct(): void{
    const id = +this.route.snapshot.paramMap.get('id');
    this.productModelService.getProductModel(id)
    .subscribe(productModel => this.currentProduct = productModel.products[0]);
  }

  getProducts(): void{
    const id = +this.route.snapshot.paramMap.get('id');
    this.productModelService.getProductModel(id)
    .subscribe(productModel => this.products = this.products.concat(productModel.products));
  }

  setCurrentProduct(product: Product): void{
    this.currentProduct = product;
    this.currentProductStockIndex = -1;
  }

  setCurrentProductStockIndex(productStockIndex: number): void{
    this.currentProductStockIndex = productStockIndex;
  }

  addProductToCart(){
    if (this.currentProductStockIndex > -1){
      this.child.setCartVisibility();
    }
    else{
      alert("Select a size before adding this product to your cart.")
    }

  }

}

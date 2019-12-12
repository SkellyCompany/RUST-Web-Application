import { Component, OnInit, ɵConsole } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/shared/services/product.service';
import { Product } from 'src/app/shared/models/product.model';
import { ProductModelService } from 'src/app/shared/services/product-model.service';
import { ProductModel } from 'src/app/shared/models/productModel.model';
import { ProductStock } from 'src/app/shared/models/productStock.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  products: Product[] = [];
  currentProduct: Product;
  currentProductStock: ProductStock;
  productModel: ProductModel;

  constructor(private productService: ProductService, private productModelService: ProductModelService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getProductModel();
    this.getProduct();
    this.getProducts();
    this.getProductStock();
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

  getProductStock(): void{
    const id = +this.route.snapshot.paramMap.get('id');
    this.productModelService.getProductModel(id)
    .subscribe(productModel => this.currentProductStock = productModel.products[0].productStocks[0]);
  }

  getProducts(): void{
    const id = +this.route.snapshot.paramMap.get('id');
    this.productModelService.getProductModel(id)
    .subscribe(productModel => this.products = this.products.concat(productModel.products));
  }

  setCurrentProduct(product: Product): void{
    this.currentProduct = product;
  }

  setCurrentProductStock(productStock: ProductStock): void{
    console.log(productStock);
  }

}

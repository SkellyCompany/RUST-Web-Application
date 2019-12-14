import { Component, OnInit, ɵConsole, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/shared/services/product.service';
import { Product } from 'src/app/shared/models/product/product.model';
import { ProductModelService } from 'src/app/shared/services/product-model.service';
import { ProductModel } from 'src/app/shared/models/product/productModel.model';
import { NavigationBarComponent } from 'src/app/shared/navigation-bar/navigation-bar.component';
import { ProductCart } from 'src/app/shared/models/productCart';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {

  @ViewChild(NavigationBarComponent, {static: false}) cart:NavigationBarComponent;
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

  getProductCart(){
    let productCart: ProductCart = {name: this.productModel.name, price: this.productModel.price, color: this.currentProduct.color, size: this.currentProduct.productStocks[this.currentProductStockIndex].productSize.size, imagePath: this.currentProduct.imagePath, quantity: 1};
    return productCart;
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
      this.cart.addProductToCart(this.getProductCart());
      this.cart.setCartVisibility();
    }
    else{
      alert("Select a size before adding this product to your cart.")
    }

  }

}

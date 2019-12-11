import { ProductModel } from './productModel.model';
import { ProductStock } from './productStock.model';

export class Product {
  id?: number;
  color: string;  
  productModel: ProductModel;
  productStock: ProductStock;
}
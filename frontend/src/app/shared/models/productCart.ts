import { ProductStock } from './product/productStock.model';

export class ProductCart {
  name: string;
  price: number;
  color: string;
  size: string;
  imagePath: string;
  quantity: number;
  productStock: ProductStock;
}
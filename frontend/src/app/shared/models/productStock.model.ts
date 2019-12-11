import { Product } from './product.model';

export class ProductStock {
  id?: number;
  product: Product;
  //productSize: ProductSize;
  quantity: number;
}
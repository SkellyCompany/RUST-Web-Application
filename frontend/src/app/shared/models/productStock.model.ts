import { Product } from './product.model';
import { ProductSize } from './productSize.model';

export class ProductStock {
  id?: number;
  product: Product;
  productSize: ProductSize;
  quantity: number;
}
import { Product } from './product.model';
import { ProductCategory } from './productCategory.model';

export class ProductModel {
  id?: number;
  name: string;
  productCategory: ProductCategory;
  // productMetric: ProductMetric;
  price: number;
  products: Product[];
  imagePath: string;
  videoPath: string
}
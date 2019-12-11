import { Product } from './product.model';

export class ProductModel {
  id?: number;
  name: string;
  price: number;
  products: Product[];
  imagePath: string;
  videoPath: string
}
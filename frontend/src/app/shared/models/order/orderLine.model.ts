import { Order } from './order.model';
import { ProductStock } from '../product/productStock.model';

export class OrderLine {
  orderId?: number;
  productStockId?: number;
  order: Order;
  productStock: ProductStock;
  quantity: number;
}
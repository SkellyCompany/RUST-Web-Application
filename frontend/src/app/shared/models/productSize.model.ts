import { ProductMetric } from './productMetric.model';

export class ProductSize {
  id?: number;
  productMetric: ProductMetric
  size: string;
  metricXValue: number;
  metricYValue: number;
  metricZValue: number;
}
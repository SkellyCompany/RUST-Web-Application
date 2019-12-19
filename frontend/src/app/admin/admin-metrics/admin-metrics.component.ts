import { Component, OnInit } from '@angular/core';
import {ProductMetric} from '../../shared/models/product/productMetric.model';
import {ProductMetricService} from '../../shared/services/product-metric.service';

@Component({
  selector: 'app-admin-metrics',
  templateUrl: './admin-metrics.component.html',
  styleUrls: ['./admin-metrics.component.scss']
})
export class AdminMetricsComponent implements OnInit {

  title = 'Metrics';
  productMetrics: ProductMetric[];

  constructor(private productMetricService : ProductMetricService) { }

  ngOnInit() {
    this.getProductCategories();
  }

  getProductCategories(): void {
    this.productMetricService.getProductMetrics().
    subscribe(productMetrics => this.productMetrics = productMetrics);
  }

}

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './shared/auth-guard/auth-guard';
import { AdminLoginComponent } from './admin/admin-login/admin-login.component';
import { HomeComponent } from './main/home/home.component';
import { VisionComponent } from './main/vision/vision.component';
import { ProductListComponent } from './main/shop/product-list/product-list.component';
import { ProductDetailsComponent } from './main/shop/product-details/product-details.component';
import { CheckoutComponent } from './main/checkout/checkout.component';
import { CreditsComponent } from './main/credits/credits.component';
import {AdminProductsComponent} from './admin/admin-products/admin-products.component';
import {AdminMetricsComponent} from './admin/admin-metrics/admin-metrics.component';
import {AdminCategoriesComponent} from './admin/admin-categories/admin-categories.component';
import {AdminOrdersComponent} from './admin/admin-orders/admin-orders.component';
import {AdminCountriesComponent} from './admin/admin-countries/admin-countries.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '', component: HomeComponent},
  { path: 'admin/login', component: AdminLoginComponent},
  { path: 'admin/products', component: AdminProductsComponent, canActivate: [AuthGuard]},
  { path: 'admin/metrics', component: AdminMetricsComponent, canActivate: [AuthGuard]},
  { path: 'admin/categories', component: AdminCategoriesComponent, canActivate: [AuthGuard]},
  { path: 'admin/orders', component: AdminOrdersComponent, canActivate: [AuthGuard]},
  { path: 'admin/countries', component: AdminCountriesComponent, canActivate: [AuthGuard]},
  { path: 'vision', component: VisionComponent},
  { path: 'shop', component: ProductListComponent},
  { path: 'shop/:category', component: ProductListComponent},
  { path: 'shop/product/:id', component: ProductDetailsComponent},
  { path: 'checkout', component: CheckoutComponent},
  { path: 'credits', component: CreditsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes),],
  exports: [RouterModule]
})
export class AppRoutingModule { }

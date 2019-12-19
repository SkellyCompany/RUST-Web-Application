import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClickOutsideModule } from 'ng-click-outside';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared/auth-guard/auth-guard';
import { AuthenticationService } from './shared/services/authentication.service';
import { NavigationBarComponent } from './shared/navigation-bar/navigation-bar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { VisionComponent } from './main/vision/vision.component';
import { ProductListComponent } from './main/shop/product-list/product-list.component';
import { ProductDetailsComponent } from './main/shop/product-details/product-details.component';
import { CreditsComponent } from './main/credits/credits.component';
import { CheckoutComponent } from './main/checkout/checkout.component';
import { HomeComponent } from './main/home/home.component';
import { AdminLoginComponent } from './admin/admin-login/admin-login.component';
import { AdminNavigationBarComponent } from './admin/admin-navigation-bar/admin-navigation-bar.component';
import { AdminProductsComponent } from './admin/admin-products/admin-products.component';
import { AdminMetricsComponent } from './admin/admin-metrics/admin-metrics.component';
import { AdminCategoriesComponent } from './admin/admin-categories/admin-categories.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
import { AdminCountriesComponent } from './admin/admin-countries/admin-countries.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    FooterComponent,
    VisionComponent,
    ProductListComponent,
    ProductDetailsComponent,
    CreditsComponent,
    CheckoutComponent,
    HomeComponent,
    AdminLoginComponent,
    AdminNavigationBarComponent,
    AdminProductsComponent,
    AdminMetricsComponent,
    AdminCategoriesComponent,
    AdminOrdersComponent,
    AdminCountriesComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ClickOutsideModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    AuthGuard,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

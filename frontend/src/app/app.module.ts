import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ClickOutsideModule } from 'ng-click-outside';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './shared/navigation-bar/navigation-bar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { VisionComponent } from './main/vision/vision.component';
import { ProductListComponent } from './main/shop/product-list/product-list.component';
import { ProductDetailsComponent } from './main/shop/product-details/product-details.component';
import { CreditsComponent } from './main/credits/credits.component';
import { CheckoutComponent } from './main/checkout/checkout.component';
import { HomeComponent } from './main/home/home.component';

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
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ClickOutsideModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

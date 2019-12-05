import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './shared/navigation-bar/navigation-bar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { VisionComponent } from './main/vision/vision.component';
import { ProductListComponent } from './main/shop/product-list/product-list.component';
import { ProductDetailsComponent } from './main/shop/product-details/product-details.component';
import { CreditsComponent } from './main/credits/credits.component';
import { CheckoutComponent } from './main/checkout/checkout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    FooterComponent,
    VisionComponent,
    ProductListComponent,
    ProductDetailsComponent,
    CreditsComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

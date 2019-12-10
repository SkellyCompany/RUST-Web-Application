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


const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'admin/login', component: AdminLoginComponent},
  { path: 'vision', component: VisionComponent },
  { path: 'shop', component: ProductListComponent },
  { path: 'shop/:id', component: ProductDetailsComponent },
  { path: 'checkout', component: CheckoutComponent},
  { path: 'credits', component: CreditsComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes),],
  exports: [RouterModule]
})
export class AppRoutingModule { }

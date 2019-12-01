import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './shared/navigation-bar/navigation-bar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { VisionComponent } from './main/vision/vision.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    FooterComponent,
    VisionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

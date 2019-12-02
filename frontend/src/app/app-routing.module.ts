import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VisionComponent } from './main/vision/vision.component';


const routes: Routes = [
  { path: 'vision', component: VisionComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

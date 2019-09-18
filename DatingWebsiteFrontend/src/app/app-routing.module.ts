import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SingInComponent } from './components/sing-in/sing-in.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { RegisterComponent } from './components/register/register.component';


const routes: Routes = [
  {path: 'home', component: MainPageComponent},
  {path: 'singIn', component: SingInComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

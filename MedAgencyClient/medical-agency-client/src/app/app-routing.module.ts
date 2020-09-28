import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CardsViewComponent } from './cards-view/cards-view.component';
import { AccountPageComponent } from './account-page/account-page.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { AboutPageComponent } from './about-page/about-page.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';

const routes: Routes = [
  { path: '', component: WelcomePageComponent},  
  { path: 'about', component: AboutPageComponent},
  { path: 'card', component: CardsViewComponent},
  { path: 'account', component: AccountPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
 // declarations: [AppComponent, CardsViewComponent, AccountPageComponent, ErrorPageComponent, AboutPageComponent, WelcomePageComponent],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CardsViewComponent } from './cards-view/cards-view.component';
import { AccountPageComponent } from './account-page/account-page.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { AboutPageComponent } from './about-page/about-page.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: 'about', component: AboutPageComponent},
  { path: 'card/:id', component: CardsViewComponent},
  { path: 'account/:id', component: AccountPageComponent},
  { path: 'error', component: ErrorPageComponent},
  { path: 'welcome', component: WelcomePageComponent},
  { path: '^^', component: NotFoundComponent},
  {path: '', redirectTo: '/welcome', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CardsViewComponent } from './cards-view/cards-view.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { AboutPageComponent } from './about-page/about-page.component';
import { AccountPageComponent } from './account-page/account-page.component';
import { HttpService } from 'src/services/http.service';
import { NotFoundComponent } from './not-found/not-found.component';
import { CallbackComponent } from './callback/callback.component';
import { ApiAuthorizationModule } from './api-authorization/api-authorization.module';

@NgModule({
  declarations: [
    AppComponent,
    CardsViewComponent,
    WelcomePageComponent,
    ErrorPageComponent,
    AboutPageComponent,
    AccountPageComponent,
    NotFoundComponent,
    CallbackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ApiAuthorizationModule,
    HttpClientModule
  ],
  providers: [HttpService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }

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

@NgModule({
  declarations: [
    AppComponent,
    CardsViewComponent,
    WelcomePageComponent,
    ErrorPageComponent,
    AboutPageComponent,
    AccountPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ValueComponent } from './components/value/value.component';
import { NavComponent } from './components/nav/nav.component';
import {FormsModule} from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { ErrorInterceptor, ErrorInterceptorProvider } from './services/error.interceptor';
import { SecurityService } from './services/security.service';
import { AlertifyService } from './services/alertify.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes.routing';
import { UserService } from './services/user.service';
import { BrowserModule } from '@angular/platform-browser';
import { TeamComponent } from './components/team/team.component';
import { UserCardComponent } from './components/team/user-card/user-card.component';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      TeamComponent,
      UserCardComponent
   ],
   imports: [
      BrowserModule ,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
    SecurityService,
    ErrorInterceptorProvider,
    AlertifyService,
    UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

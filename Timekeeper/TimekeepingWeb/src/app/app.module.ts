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
import { TabsModule} from 'ngx-bootstrap/tabs';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes.routing';
import { UserService } from './services/user.service';
import { BrowserModule } from '@angular/platform-browser';
import { TeamComponent } from './components/team/team.component';
import { UserCardComponent } from './components/team/user-card/user-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { UserDetailComponent } from './components/team/user-detail/user-detail.component';
import { UserDetailResolver } from './resolver/user-detail.resolver';
import { UserListResolver } from './resolver/user-list.resolver';
// import { NgxGalleryModule } from 'ngx-gallery';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      TeamComponent,
      UserCardComponent,
      UserDetailComponent
   ],
   imports: [
      BrowserModule ,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
        config: {
          tokenGetter,
          whitelistedDomains: ['localhost:5000'],
          blacklistedRoutes: ['localhost:5000/api/auth']
        }
      }),
      TabsModule.forRoot(),
      NgxGalleryModule
   ],
   providers: [
    SecurityService,
    ErrorInterceptorProvider,
    AlertifyService,
    UserService,
    UserDetailResolver,
    UserListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

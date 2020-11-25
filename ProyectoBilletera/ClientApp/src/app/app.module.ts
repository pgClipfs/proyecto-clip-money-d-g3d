import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/signup.component';

import { UsuarioService } from './service/usuario.service';
import { AuthGuard } from './security/auth.guard';
<<<<<<< HEAD

import { JwtInterceptor } from './security/jwt.interceptor';
=======
>>>>>>> c90b3cfec7f118cef8ca70ceb95b4688c71f8eb4

import { JwtInterceptor } from './security/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteComponent,
    LoginComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      /* { path: '', component: HomeComponent, pathMatch: 'full' }, */
<<<<<<< HEAD
      { path: '', redirectTo: 'login', pathMatch: 'full' },
=======
<<<<<<< HEAD
      { path: '', redirectTo: 'login', pathMatch: 'full' },
=======
      { path: '', redirectTo: 'login', pathMatch: 'full', canActivate: [AuthGuard] },
>>>>>>> c90b3cfec7f118cef8ca70ceb95b4688c71f8eb4
>>>>>>> main
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] }, 
      { path: 'login', component: LoginComponent},
      { path: 'counter', component: CounterComponent, canActivate: [AuthGuard] },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
      { path: 'cliente', component: ClienteComponent, canActivate: [AuthGuard] },
      { path: 'signup', component: SignUpComponent }
    ])
  ],
  providers: [UsuarioService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

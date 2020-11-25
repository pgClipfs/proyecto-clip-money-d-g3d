import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from '../service/auth.service';


@Injectable({ providedIn: 'root' })

export class AuthGuard implements CanActivate {

  constructor(private router: Router, private authService: AuthService) {

  }
  canActivate(route: ActivatedRouteSnapshot) {
    const usuario = this.authService.usuarioData;
    if (usuario) {
      return true;
    }
    this.router.navigate(['/']);

    return false;
  }
}

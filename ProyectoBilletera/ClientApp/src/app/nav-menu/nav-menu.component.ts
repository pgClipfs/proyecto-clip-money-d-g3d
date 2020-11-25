import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  
  constructor(public auth: AuthService, private router: Router) {

    if (this.auth.usuarioData) {
      this.router.navigate(['/home']);
    } else {
      this.router.navigate(['/login']);
    }
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    var alerta = false;
    console.log('cerrar sesion');
    console.log(localStorage.getItem('usuario'));

    if (localStorage.getItem('usuario') != null) {
      localStorage.removeItem('usuario');
      location.reload();
    }
    else {
      this.router.navigate(['/login']);
      alert('Debe iniciar sesión');
      return alerta = true;
    }
    
<<<<<<< HEAD
   
=======
   // window.location.href = "https://localhost:5001/login";
>>>>>>> main
  }

}

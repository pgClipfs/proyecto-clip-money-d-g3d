import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
import { Router } from '@angular/router';
=======
<<<<<<< HEAD
import { Router } from '@angular/router';
=======
>>>>>>> c90b3cfec7f118cef8ca70ceb95b4688c71f8eb4
>>>>>>> main
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public nombreUsuario: string;
  public password: string;
<<<<<<< HEAD
 
  exito: number; 

  constructor(public auth: AuthService, private router: Router) {
   
    if (this.auth.usuarioData) {
      this.router.navigate(['home']);
    }
=======
<<<<<<< HEAD
 
  exito: number; 

  constructor(public auth: AuthService, private router: Router) {
   
    if (this.auth.usuarioData) {
      this.router.navigate(['home']);
    }
=======

  constructor(public auth: AuthService) {

>>>>>>> c90b3cfec7f118cef8ca70ceb95b4688c71f8eb4
>>>>>>> main
  }

  ngOnInit() {

  }

  login() {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> main
    this.auth.login(this.nombreUsuario, this.password).subscribe(respuesta => {    
      console.log(respuesta)
      console.log(respuesta.exito)

      if (respuesta.exito === 1) {
        this.router.navigate(['/home']);
      }
<<<<<<< HEAD
=======
=======
    this.auth.login(this.nombreUsuario, this.password).subscribe(r => {
      console.log(r);
>>>>>>> c90b3cfec7f118cef8ca70ceb95b4688c71f8eb4
>>>>>>> main
    });
  }
}

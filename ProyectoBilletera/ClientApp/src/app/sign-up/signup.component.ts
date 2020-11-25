import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { UsuarioService } from '../service/usuario.service';
import { Usuario } from '../interface/interfaces';
import { Observable } from 'rxjs';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignUpComponent {
  public lstUsuarios: Observable<Usuario[]>;

  nombreUsuario = new FormControl(''/*, [Validators.required, Validators.minLength(4)]*/);
  passUsuario = new FormControl(''/*, [Validators.required, Validators.minLength(8)]*/);
  passPrueba = new FormControl('');
  fecha = new Date;
  fechaAlta = this.fecha.getFullYear() + '-' + (this.fecha.getMonth()+1) + '-' + this.fecha.getDate();
  estado = 0;
  contrasenha = '';
  contrasenhaPrueba = '';
  username = '';

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected usuarioService: UsuarioService) {
    this.GetUsuario();
  }

  public GetUsuario() {
    this.lstUsuarios = this.usuarioService.GetUsuarios();
  }

  public PostUser() {
    this.contrasenha = this.passUsuario.value;
    this.username = this.nombreUsuario.value;
    this.contrasenhaPrueba = this.passPrueba.value;

    if (this.username != '' && (this.contrasenha === this.contrasenhaPrueba)) {
      if (this.contrasenha.length >= 8) {
        this.usuarioService.AddUsuario(this.nombreUsuario.value, this.passUsuario.value, this.fechaAlta, this.estado);

        this.nombreUsuario.setValue('');
        this.passUsuario.setValue('');
        this.passPrueba.setValue('');
        
        alert('Bienvenido: ' + this.username)
        location.reload();
      }
    } if (this.username == '') {
      this.nombreUsuario.setValue('');
      this.passUsuario.setValue('');
      this.passPrueba.setValue('');
      alert('Ingrese Nombre De Usuario');
    } if (this.contrasenha != this.contrasenhaPrueba) {
      this.nombreUsuario.setValue('');
      this.passUsuario.setValue('');
      this.passPrueba.setValue('');
      alert('Los Passwords No Coinciden');
    }
    if (this.username == '' && (this.contrasenha != this.contrasenhaPrueba)) {
      this.nombreUsuario.setValue('');
      this.passUsuario.setValue('');
      this.passPrueba.setValue('');
      alert('Los Campos No Son Válidos');
    }
    if (this.contrasenha == '' || this.contrasenhaPrueba=='') {
      this.nombreUsuario.setValue('');
      this.passUsuario.setValue('');
      this.passPrueba.setValue('');
      alert('Contraseña Vacia')
    }

    
  }
}



import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Usuario } from '../interface/interfaces';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'token-auth'
  })
}

@Injectable({
  providedIn: 'root',
})

export class UsuarioService {
  public test: string = "USUARIO SERVICE";
  baseUrl: string;

  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetUsuarios(): Observable<Usuario[]> {
    let http: HttpClient; 
    return this.http.get<Usuario[]>(this.baseUrl + "api/Usuario/Usuarios");
  }

  public AddUsuario(nombreUsuario, password, fechaAlta, estado) {
    this.http.post<Response>(this.baseUrl + "api/Usuario/Add",
      {
        'NombreUsuario': nombreUsuario,
        'Password': password,
        'FechaAlta': fechaAlta,
        'Estado': estado
      }, httpOptions).
        subscribe(resultado => {
        console.log(resultado);
        }, error => console.error(error));
  }
}

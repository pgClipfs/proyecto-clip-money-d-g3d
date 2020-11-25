import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Response, UsuarioLogin } from '../interface/interfaces';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'token-auth'
  })
}


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string = 'https://localhost:5001/api/Usuario/login';

  private usuarioSubject: BehaviorSubject<UsuarioLogin>;
    

  public get usuarioData(): UsuarioLogin {
    return this.usuarioSubject.value;
  }

  constructor(private _http: HttpClient) {
    this.usuarioSubject = new BehaviorSubject<UsuarioLogin>(
      JSON.parse(localStorage.getItem('usuario'))
    );
  }

  login(nombreUsuario: string, password: string): Observable<Response>{
    
    return this._http.post<Response>(this.url, { nombreUsuario, password }, httpOptions).pipe(
      map(respuesta => {
        //console.log(respuesta)
        //console.log(respuesta.Exito)
        if (respuesta.exito === 1) {
          const usuario: UsuarioLogin = respuesta.data;
          localStorage.setItem('usuario', JSON.stringify(usuario));
          this.usuarioSubject.next(usuario);
        }
        return respuesta;
      })
    );

  }

  logout() {
    localStorage.removeItem('usuario');
    this.usuarioSubject.next(null);
  }
}

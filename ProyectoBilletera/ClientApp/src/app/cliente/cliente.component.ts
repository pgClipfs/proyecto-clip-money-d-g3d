import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-cliente',
  templateUrl: "./cliente.component.html"
})

export class ClienteComponent {
  public listaClientes: Cliente[];

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Cliente[]>(baseUrl + "api/Cliente/GetList").subscribe(result => {
      this.listaClientes = result;
    }, error => console.error(error));
  }
}

interface Cliente {
  IdCliente: number;
  Nombre: string;
  Apellido: string;
  Estado: string;
  IdDireccion: number;
  NroTelefono: string;
  NroDni: string;
  Email: string;
  NomDireccion: string;
  NomLocalidad: string;
  NomProvincia: string;
  IdUsuario: string;
}

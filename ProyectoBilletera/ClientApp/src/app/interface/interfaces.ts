export interface Usuario {
  NombreUsuario: string,
  Password: string;
  FechaAlta: Date;
  Estado: number;
}

export interface Response {
  exito: number,
  mensaje: string,
  data: any
}

export interface UsuarioLogin{
  NombreUsuario: string,
  Token: string
}

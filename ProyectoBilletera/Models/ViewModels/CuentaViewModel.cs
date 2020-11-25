using System;

namespace Clip.Models.ViewModels
{
    public class CuentaViewModel
    {
        public int IdCuenta { get; set; }
        public int? IdEntidadBancaria { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoMoneda { get; set; }
        public string Cvu { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Estado { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? TopeDescubierto { get; set; }

        //datos linkeados
        public string NomBanco { get; set; }
        public string NomCliente { get; set; }
        public string NomMoneda { get; set; }
    }
}

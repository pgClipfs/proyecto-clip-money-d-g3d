namespace Clip.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Estado { get; set; }
        public int? IdDireccion { get; set; }
        public string NroTelefono { get; set; }
        public string NroDni { get; set; }
        public byte[] FrontalDni { get; set; }
        public byte[] TraseraDni { get; set; }
        public string Email { get; set; }
        public int? IdUsuario { get; set; }

        //agregamos el campo en el view model para traerlo en la consulta
        public string NomDireccion { get; set; }
        public string NomLocalidad { get; set; }
        public string NomProvincia { get; set; }

    }
}


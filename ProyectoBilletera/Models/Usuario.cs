using System;
using System.Collections.Generic;

#nullable disable

namespace Clip.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

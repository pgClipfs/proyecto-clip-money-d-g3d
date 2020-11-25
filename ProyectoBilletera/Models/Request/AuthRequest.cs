using System.ComponentModel.DataAnnotations;

namespace Clip.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using Clip.Models;
using Clip.Models.Request;
using Clip.Models.Response;
using Clip.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Clip.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppSettings _appSettings;

        public UsuarioService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public LoginResponse Auth(AuthRequest userRequest)
        {
            LoginResponse login = new LoginResponse();
            using (var db = new billetera_virtualContext())
            {
                /* https://hdeleon.net/funcion-para-encriptar-en-sha256-en-c-net/ */
                // creditos a hdeleon

                string encryptPassword = Encrypter.GetSHA256(userRequest.Password);

                var usuario = db.Usuarios.Where(u => u.NombreUsuario == userRequest.NombreUsuario 
                                                && u.Password == encryptPassword).FirstOrDefault();

                if (usuario == null)
                {
                    return null;
                }
                login.NombreUsuario = usuario.NombreUsuario;
                login.Token = GetToken(usuario);
            }
            return login;
        }

         private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Name, usuario.NombreUsuario.ToString()),

                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

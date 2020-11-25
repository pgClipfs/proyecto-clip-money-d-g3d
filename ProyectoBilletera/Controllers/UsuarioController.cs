using Clip.Models.Request;
using Clip.Models.Response;
using Clip.Services;
using Clip.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clip.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class UsuarioController : Controller
    {
        private readonly Models.billetera_virtualContext db;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(Models.billetera_virtualContext context, IUsuarioService usuarioService)
        {
            db = context;
            _usuarioService = usuarioService;
        }

        [HttpGet("[action]")]
        public IActionResult Usuarios()
        {
            List<Models.Usuario> usuarios = db.Usuarios.ToList();
            return Json(usuarios);
        }

        [HttpPost("[action]")]
        public Response Add([FromBody] Models.Usuario _user)
        {
            Response oResponse = new Response();
            Models.Usuario oUsuario = new Models.Usuario();

            try {

                oUsuario.NombreUsuario = _user.NombreUsuario;
                oUsuario.Password = Encrypter.GetSHA256(_user.Password);
                oUsuario.FechaAlta = _user.FechaAlta;
                oUsuario.Estado = _user.Estado;

                db.Usuarios.Add(oUsuario);
                db.SaveChanges();

                //codigo de exito = 1, si da error es = 0
                oResponse.Exito = 1;
            }
            catch(Exception e)
            {
                oResponse.Exito = 0;
                oResponse.Mensaje = e.Message;
            }
            return oResponse;
        }

        [HttpPost("login")]
        public IActionResult Autentificacion([FromBody] AuthRequest request)
        {
            Response response = new Response();
            var loginReponse = _usuarioService.Auth(request);

            if (loginReponse == null)
            {
                response.Mensaje = "Usuario o Password Incorrectos";
                response.Exito = 0;
                return BadRequest(response);
            }

            response.Mensaje = "Login con Exito";
            response.Exito = 1;
            response.Data = loginReponse;

            return Ok(response);
        }

        
    }
}

using Clip.Models.Response;
using Clip.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clip.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        //revisar el readonly por las dudas
        private readonly Models.billetera_virtualContext db;

        public ClienteController(Models.billetera_virtualContext context)
        {
            db = context;
        }
        [HttpGet("[action]")]
        public IEnumerable<ClienteViewModel> GetList()
        {

            List<ClienteViewModel> lista = (from d in db.Clientes
                                            join l in db.Direccions on d.IdDireccion equals l.IdDireccion
                                            join c in db.Localidads on l.IdLocalidad equals c.IdLocalidad
                                            join p in db.Provincia on c.IdProvincia equals p.IdProvincia
                                            //es inner join revisar, sino cambiar a left join 
                                            select new ClienteViewModel
                                            {
                                                IdCliente = d.IdCliente,
                                                Nombre = d.Nombre,
                                                Apellido = d.Apellido,
                                                Estado = d.Estado,
                                                IdDireccion = d.IdDireccion,
                                                NroTelefono = d.NroTelefono,
                                                NroDni = d.NroDni,
                                                FrontalDni = d.FrontalDni,
                                                TraseraDni = d.TraseraDni,
                                                Email = d.Email,
                                                IdUsuario = d.IdUsuario,
                                                NomDireccion = l.Calle,
                                                NomLocalidad = c.Nombre,
                                                NomProvincia = p.Nombre
                                            }).ToList();
            return lista;

        }


        /*
        
        [HttpGet("{id}")]
        public IEnumerable<ClienteViewModel> GetById(int id)
        {

            IEnumerable<ClienteViewModel>lista = (IQueryable<ClienteViewModel>)((from c in db.Clientes
                                             join d in db.Direccions on c.IdDireccion equals d.IdDireccion
                                             join l in db.Localidads on d.IdLocalidad equals l.IdLocalidad
                                             join p in db.Provincia on l.IdProvincia equals p.IdProvincia
                                             select new ClienteViewModel
                                             {
                                                 IdCliente = c.IdCliente,
                                                 Nombre = c.Nombre,
                                                 Apellido = c.Apellido,
                                                 Estado = c.Estado,
                                                 IdDireccion = c.IdDireccion,
                                                 Cvu = c.Cvu,
                                                 NroTelefono = c.NroTelefono,
                                                 NroDni = c.NroDni,
                                                 FrontalDni = c.FrontalDni,
                                                 TraseraDni = c.TraseraDni,
                                                 Email = c.Email,
                                                 NomDireccion = d.Calle,
                                                 NomLocalidad = l.Nombre,
                                                 NomProvincia = p.Nombre
                                             })).ToList();
            lista = lista.Where(c => c.IdCliente == id);
            return lista;

        }
        */

        [HttpPost("[action]")]
        public Response Add(ClienteViewModel cliente)
        {
            Response oRespuesta = new Response();
            try 
            {
                Models.Cliente oCliente = new Models.Cliente
                {
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    NroDni = cliente.NroDni,
                    NroTelefono = cliente.NroTelefono,
                    Estado = cliente.Estado,
                    Email = cliente.Email
                };

                db.Clientes.Add(oCliente);
                db.SaveChanges();

                oRespuesta.Exito = 1;
            }
            catch(Exception e)
            {
                oRespuesta.Exito = 0;
                oRespuesta.Mensaje = e.Message; 
            }
            return oRespuesta;
        }

    }
}
    


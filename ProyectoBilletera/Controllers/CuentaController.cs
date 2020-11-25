using Clip.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Clip.Controllers
{
    [Route("api/[controller]")]
    public class CuentaController : Controller
    {
        //revisar el readonly por las dudas
        private readonly Models.billetera_virtualContext db;

        public CuentaController(Models.billetera_virtualContext context)
        {
            db = context;
        }
        [HttpGet("[action]")]
        public IEnumerable<CuentaViewModel> GetList()
        {


            List<CuentaViewModel> lista = (from c in db.Cuenta
                                            
                                            //es inner join revisar, sino cambiar a left join 
                                            select new CuentaViewModel
                                            {
                                                
                                            }).ToList();
            return lista;
        }
    }
}

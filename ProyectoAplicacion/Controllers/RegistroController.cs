using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAplicacion.Entities;
using ProyectoAplicacion.Models;

namespace ProyectoAplicacion.Controllers
{
    [FiltroSesion]
    [OutputCache(NoStore = true, Duration = 0)]
    public class RegistroController : Controller
    {
        RegistroModel modelo = new RegistroModel();

        [HttpGet]
        [Route("ConsultarRegistros")]
        public ActionResult ConsultarRegistroCompras()
        {
            try
            {
                var datos = modelo.ConsultarRegistroCompras();
                if (datos == null)
                {
                    return View("Error");
                }
                else
                {
                    return View(datos);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("ConsultarRegistros")]
        public ActionResult ConsultarRegistroInventario()
        {
            try
            {
                var datos = modelo.ConsultarRegistroInventario();
                if (datos == null)
                {
                    return View("Error");
                }
                else
                {
                    return View(datos);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Route("ConfirmarCompra")]
        public ActionResult ConfirmarCompra(Registros registro)
        {
            try
            {
                modelo.ConfirmarCompra(registro);
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //la vista tiene que estar en registor o redireccionar a carrito




    }
}
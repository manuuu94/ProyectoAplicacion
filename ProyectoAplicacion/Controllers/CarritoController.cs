using ProyectoAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAplicacion.Controllers
{
    [FiltroSesion]
    [OutputCache(NoStore = true, Duration = 0)]
    public class CarritoController : Controller
    {
        CarritoModel modelo = new CarritoModel();

        [HttpGet]
        [Route("ConsultarCarrito")]
        public ActionResult ConsultarCarrito()
        {
            try
            {
                var datos = modelo.ConsultarCarrito();
                if (datos.Count != 0)
                {
                    Session["TOTALCOMPRA"] = datos.LastOrDefault().TOTAL_CARRITO;
                    return View(datos);
                }
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("VaciarCarrito")]
        public ActionResult VaciarCarrito()
        {
            try
            {
                modelo.VaciarCarrito();
                return RedirectToAction("ConsultarCarrito");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("EliminarProductoCarrito")]
        public ActionResult EliminarProductoCarrito(int ID_PROD)
        {
            try
            {
                modelo.EliminarProductoCarrito(ID_PROD);
                return RedirectToAction("ConsultarCarrito");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        [HttpGet]
        [Route("ConfirmarCompra")]
        public ActionResult ConfirmarCompra()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }



    }
}
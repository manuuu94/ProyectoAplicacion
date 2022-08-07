using ProyectoAplicacion.Entities;
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
    public class InventarioController : Controller
    {
        InventarioModel modelo = new InventarioModel();
        CarritoModel modelocarrito = new CarritoModel();

        //el get es para entrar a las pantallas.
        //el post es para realizar transacciones.
        [HttpGet]
        [Route("ConsultarInventario")]
        public ActionResult ConsultarInventario()
        {
            try
            {
                var datos = modelo.ConsultarInventario();
                if (datos == null)
                {
                    return View("Error");
                }
                else
                {
                    //ir a la vista
                    return View(datos);

                }

            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AñadirCarrito(Inventario producto)
        {
            ViewBag.Mensaje = string.Empty;

            var respuesta = modelo.AñadirCarrito(producto);

            if (respuesta != null)
            {
                return RedirectToAction("ConsultarInventario", "Inventario");
            }
            ViewBag.Mensaje = "Error";
            return RedirectToAction("ConsultarInventario", "Inventario");

        }

        [HttpGet]
        public ActionResult AñadirCarrito2(string descripcion, decimal precio, int cantidad, int id_producto)
        {
            var respuesta = modelo.AñadirCarrito2(descripcion,precio,cantidad,id_producto);
            if (respuesta)
            {
                return RedirectToAction("ConsultarInventario", "Inventario"); //RedirectToAction("ConsultarCarrito", "Carrito");
            }
            return RedirectToAction("ConsultarInventario", "Inventario");
        }

        [HttpGet]
        public ActionResult EliminarProducto(int ID_PRODUCTO)
        {
            modelo.EliminarProducto(ID_PRODUCTO);

            return RedirectToAction("ConsultarInventario", "Inventario");

        }


        [HttpGet]
        [Route("AñadirProducto")]
        public ActionResult AñadirProducto()
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

        [HttpPost]
        [Route("AñadirProducto")]
        public ActionResult AñadirProducto(Inventario producto)
        {
            try
            {
                modelo.AñadirProducto(producto);
                return RedirectToAction("ConsultarInventario");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }



    }
}
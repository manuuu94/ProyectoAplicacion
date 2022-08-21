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
    public class EmpleadoController : Controller
    {
        EmpleadoModel modelo = new EmpleadoModel();


        [HttpGet]
        public ActionResult ConsultarEmpleados()
        {
            try
            {
                var datos = modelo.ConsultarEmpleados();
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

        [HttpGet]
        public ActionResult ConsultarEmpleado(int ID_EMPLEADO)
        {
            try
            {
                var datos = modelo.ConsultarEmpleado(ID_EMPLEADO);
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                modelo.ActualizarEmpleado(empleado);
                return RedirectToAction("ConsultarEmpleados", "Empleado");
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [HttpGet]
        public ActionResult EliminarEmpleado(int ID_EMPLEADO)
        {
            try
            {
                modelo.EliminarEmpleado(ID_EMPLEADO);

                return RedirectToAction("ConsultarEmpleados", "Empleado");
            }
            catch (Exception)
            {
                return View("Error");
            }

        }


        [HttpGet]
        public ActionResult RegistrarEmpleado()
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
        public ActionResult RegistrarEmpleado(Empleado empleado)
        {
            try
            {
                modelo.RegistrarEmpleado(empleado);
                return RedirectToAction("ConsultarEmpleados");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }




    }
}
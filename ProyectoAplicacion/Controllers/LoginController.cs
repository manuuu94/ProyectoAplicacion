using ProyectoAplicacion.Models;
using ProyectoAplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace ProyectoAplicacion.Controllers
{
    public class LoginController : Controller
    {
        LoginModel modelo = new LoginModel();

        [HttpGet]
        public ActionResult Index()
        {
           return View();

        }

        [HttpGet]
        public ActionResult LogOut()
        {

            Session.Clear(); 
            Session.Abandon();


            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult ResetPass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Empleado empleado)
        {
            ViewBag.Mensaje = string.Empty;
            var respuesta = modelo.ValidarUsuario(empleado);
            if (respuesta != null)
            {
                Session["RolUsuario"] = respuesta.ID_ROL;
                Session["NombreUsuario"] = respuesta.NOMBRE;
                Session["ApellidoUsuario"] = respuesta.APELLIDO1;
                Session["Usuario"] = respuesta.USERNAME;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Mensaje = "Credenciales Incorrectos";
            return View();
        }

        [HttpPost]
        public ActionResult ResetPass(ResPass respass)
        {
            ViewBag.Mensaje = string.Empty;
            var respuesta = modelo.RecuperarContraseña(respass);
            if (respuesta != null)
            {
                string contraseñaNueva = modelo.CreatePassword();
                respass.PASSWORD = contraseñaNueva;
                modelo.CambiarContraseña(respass);
                modelo.EnviarCorreo(respuesta.CORREO, "Recuperación contraseña", 
                    "Su nueva contraseña es: " +
                    ""+contraseñaNueva);

                ViewBag.Mensaje = "Correo enviado, pruebe de nuevo";
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Mensaje = "Usuario no existe";
            return View();
        }


        [HttpGet]
        public ActionResult cambioContraseña()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cambiarContraseña(ResPass respass)
        {
            respass.USERNAME = Session["Usuario"].ToString();
            var respuesta = modelo.CambiarContraseña(respass);
            return RedirectToAction("cambioContraseña", "Login");
        }





    }
}
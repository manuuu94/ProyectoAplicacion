using ProyectoAplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoAplicacion.Models
{
    public class EmpleadoModel
    {
        public List<Empleado> ConsultarEmpleados()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConsultarEmpleados";
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<List<Empleado>>().Result;
                }
                return null;
            }
        }


       public Empleado ConsultarEmpleado(int ID_EMPLEADO)
        {
            using (var cliente = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConsultarEmpleado?ID_EMPLEADO=" + ID_EMPLEADO;
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Empleado>().Result;
                }
                return null;
            }
        }


        public bool ActualizarEmpleado(Empleado empleado)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(empleado);
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ActualizarEmpleado";
                HttpResponseMessage respuesta = cliente.PutAsync(url + metodo, info).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }


        public bool EliminarEmpleado(int ID_EMPLEADO)
        {
            using (var cliente = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/EliminarEmpleado?ID_EMPLEADO=" + ID_EMPLEADO;

                HttpResponseMessage respuesta = cliente.DeleteAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public bool RegistrarEmpleado(Empleado empleado)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(empleado);
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/RegistrarEmpleado" ;
                HttpResponseMessage respuesta = cliente.PostAsync(url + metodo, info).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //return respuesta.Content.ReadAsAsync<carro>().Result;
                    return true;
                }
                return false;
            }
        }

    }
}
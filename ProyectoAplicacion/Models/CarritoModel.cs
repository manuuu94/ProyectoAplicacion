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
    public class CarritoModel
    {
        public List<carro> ConsultarCarrito()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/mostrarCarrito";
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<List<carro>>().Result;
                }
                return null;
            }
        }

        public bool VaciarCarrito()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/VaciarCarrito";
                HttpResponseMessage respuesta = cliente.DeleteAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public bool EliminarProductoCarrito(int ID_PROD)
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/EliminarProductoCarrito?ID_PROD="+ID_PROD; 
                HttpResponseMessage respuesta = cliente.DeleteAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

    }
}

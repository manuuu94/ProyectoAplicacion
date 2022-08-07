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
    public class InventarioModel
    {
        public List<Inventario> ConsultarInventario()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConsultarInventario";
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<List<Inventario>>().Result;
                }
                return null;
            }
        }


        public carro AñadirCarrito(Inventario producto)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(producto);
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/AñadirCarrito";
                HttpResponseMessage respuesta = cliente.PostAsync(url + metodo, info).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<carro>().Result;
                }
                return null;
            }
        }

        public bool AñadirCarrito2(string descripcion, decimal precio, int cantidad, int id_producto)
        {
            using (var cliente = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/AñadirCarrito2?descripcion="+descripcion+
                    "&precio="+precio.ToString().Replace(",", ".") + "&cantidad="+cantidad+"&id_producto="+id_producto;

                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public bool EliminarProducto(int ID_PRODUCTO)
        {
            using (var cliente = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/EliminarProducto?ID_PRODUCTO="+ID_PRODUCTO;

                HttpResponseMessage respuesta = cliente.DeleteAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public bool AñadirProducto(Inventario producto)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(producto);
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/RegistrarProducto";
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

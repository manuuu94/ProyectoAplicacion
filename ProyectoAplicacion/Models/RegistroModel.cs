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
    public class RegistroModel
    {
        public List<Registros> ConsultarRegistroCompras()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConsultarRegistrosCompras";
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<List<Registros>>().Result;
                }
                return null;
            }
        }

        public List<RegistrosInventario> ConsultarRegistroInventario()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConsultarRegistrosInventario";
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<List<RegistrosInventario>>().Result;
                }
                return null;
            }
        }


        public bool ConfirmarCompra(Registros registro)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(registro);
                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConfirmaCompra";
                HttpResponseMessage respuesta = cliente.PostAsync(url + metodo, info).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //return respuesta.Content.ReadAsAsync<carro>().Result;
                    return true;
                }
                return false;
            }
        }

        public List<Cliente> ConsultarRegistroClientesAtendidos()
        {
            using (var cliente = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ConsultarRegistroClientesAtendidos";
                HttpResponseMessage respuesta = cliente.GetAsync(url + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<List<Cliente>>().Result;
                }
                return null;
            }
        }


    }
}

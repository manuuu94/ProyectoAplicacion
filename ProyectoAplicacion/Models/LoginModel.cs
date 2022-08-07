using ProyectoAplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace ProyectoAplicacion.Models
{
    public class LoginModel
    {

        public Empleado ValidarUsuario(Empleado empleado)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(empleado);

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/ValidarUsuario";
                HttpResponseMessage respuesta = cliente.PostAsync(url + metodo, info).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Empleado>().Result;
                }
                return null;
            }
        }
       public ResPass RecuperarContraseña(ResPass respass)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(respass);

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/RecuperarContraseña";
                HttpResponseMessage respuesta = cliente.PostAsync(url + metodo, info).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<ResPass>().Result;
                }
                return null;
            }
        }
        public bool CambiarContraseña(ResPass respass)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent info = JsonContent.Create(respass);

                string url = ConfigurationManager.AppSettings["urlApiProyecto"].ToString();
                string metodo = "api/CambiarContraseña";
                HttpResponseMessage respuesta = cliente.PutAsync(url + metodo, info).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public void EnviarCorreo(string email, string asunto, string mensaje)
        {
            string correo = ConfigurationManager.AppSettings["Correo"].ToString();
            string clave = ConfigurationManager.AppSettings["Clave"].ToString();

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(correo, clave);
            MailAddress from = new MailAddress(correo, String.Empty, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);

            message.Body = mensaje;
            message.BodyEncoding = System.Text.Encoding.UTF8; 

            message.Subject = asunto;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            client.Send(message);
        }
        public string CreatePassword(int length = 10)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }






    }
}

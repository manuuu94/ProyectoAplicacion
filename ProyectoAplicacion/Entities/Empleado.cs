﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAplicacion.Entities
{
    public class Empleado
    {
        public int ID_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO1 { get; set; }
        public string APELLIDO2 { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public int ID_ROL { get; set; }
        public string CORREO { get; set; }

    }


    public class ResPass
    {
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string CORREO { get; set; }
    }
}
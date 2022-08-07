﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAplicacion.Models;


namespace ProyectoAplicacion.Controllers
{
    [FiltroSesion]
    [OutputCache(NoStore = true, Duration = 0)]
    public class HomeController : Controller
    { 
        public ActionResult Index()
    {
        return View();
    }
    
        public ActionResult Maps()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
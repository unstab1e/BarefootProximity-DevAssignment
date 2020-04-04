﻿using DevAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BarefootProximityModel model = new Models.BarefootProximityModel();
            return View(model);
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
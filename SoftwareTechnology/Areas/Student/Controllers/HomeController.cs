﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        // GET: Student/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
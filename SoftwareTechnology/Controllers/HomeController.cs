using SoftwareTechnology.Common;
using SoftwareTechnology.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Home = "active-menu";
            ViewBag.Login = "menu-style";
            return View();
        }
    }
}
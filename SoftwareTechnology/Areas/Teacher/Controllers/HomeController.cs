using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Teacher.Controllers
{
    public class HomeController : Controller
    {
        // GET: Teacher/Home
        public ActionResult Index()
        {
            if(Session["userName"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "active-menu";
            ViewBag.ChangePass = "menu-style";
            ViewBag.Schedule = "menu-style";
            ViewBag.Accept = "menu-style";
            return View();
        }
    }
}
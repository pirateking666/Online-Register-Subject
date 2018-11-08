using System;
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
            if (Session["userName"] == null || (int)Session["positionID"] != 3)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "active-menu";
            ViewBag.ChangePass = "menu-style";
            ViewBag.Schedule = "menu-style";
            ViewBag.RegisterClass = "menu-style";
            return View();
        }
    }
}
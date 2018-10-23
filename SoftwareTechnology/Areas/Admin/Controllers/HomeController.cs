using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Home = "active-menu";
            ViewBag.ChangePass = "menu-style";
            ViewBag.CreateAcc = "menu-style";
            ViewBag.ListSub = "menu-style";
            ViewBag.ListRegis = "menu-style";
            return View();
        }
    }
}
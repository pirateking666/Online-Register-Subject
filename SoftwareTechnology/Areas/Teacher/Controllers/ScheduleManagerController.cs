using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Teacher.Controllers
{
    public class ScheduleManagerController : Controller
    {
        // GET: Teacher/ScheduleManager
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.Schedule = "active-menu";
            ViewBag.Accept = "menu-style";
            ViewBag.ListSubject = new ModifySubjectProgram().GetList((int)Session["branchID"]);
            return View();
        }
    }
}
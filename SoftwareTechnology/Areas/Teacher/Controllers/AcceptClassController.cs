using SoftwareTechnology.Areas.Teacher.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Teacher.Controllers
{
    public class AcceptClassController : Controller
    {
        // GET: Teacher/AcceptClass
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.Schedule = "menu-style";
            ViewBag.Accept = "active-menu";
            new ModifyClass().ChangeStatusClass();
            new ModifyClass().ChangeStatusClassByNumberOfStudent();
            new ModifyClass().ChangeStatusClassIfItEnd();
            new ModifyClass().ChangeStatusClassRe();
            new ModifyClass().ChangeStatusIfTeacherNotReceive();
            new ModifyClass().ChangeStatusIfClassReEnd();
            ViewBag.ListClassRe = new ModifyClass().GetListClassWithStatusIDAndClassTypeID(2, 2);
            return View();
        }
        public JsonResult Accept(int ClassID, int dayID, int timeID)
        {
            return Json(new AcceptClass().ReceiveClass(ClassID, (string)Session["username"], dayID, timeID), JsonRequestBehavior.AllowGet);
        }
    }
}
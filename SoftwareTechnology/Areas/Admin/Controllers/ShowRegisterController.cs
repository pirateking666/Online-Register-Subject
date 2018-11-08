using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Admin.Controllers
{
    public class ShowRegisterController : Controller
    {
        // GET: Admin/ShowRegister
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.CreateAcc = "menu-style";
            ViewBag.OpenRegis = "menu-style";
            ViewBag.ListRegis = "active-menu";
            new ModifyClass().ChangeStatusClass();
            new ModifyClass().ChangeStatusClassByNumberOfStudent();
            new ModifyClass().ChangeStatusClassIfItEnd();
            new ModifyClass().ChangeStatusClassRe();
            new ModifyClass().ChangeStatusIfTeacherNotReceive();
            new ModifyClass().ChangeStatusIfClassReEnd();
            ViewBag.ListClass = new ModifyClass().GetList();
            ViewBag.ListClassRe = new ModifyClass().GetListClassRe(); 
            return View();
        }
    }
}
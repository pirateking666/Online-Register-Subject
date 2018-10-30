using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Admin.Controllers
{
    public class OpenRegisterController : Controller
    {
        // GET: Admin/OpenRegister
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.CreateAcc = "menu-style";
            ViewBag.OpenRegis = "active-menu";
            ViewBag.ListRegis = "menu-style";
            ViewBag.ListBranch = new ModifyBranch().GetListBranch();
            ViewBag.ListCourse = new ModifyCourse().GetListCourse();
            ViewBag.ListSubject = new ModifySubjectProgram().GetList();
            ViewBag.CurrentYear = DateTime.Now.Year;
            if( new ModifyOpenRegister().CheckStatus())
            {
                ViewBag.Style = "height:500px;";
            }
            else
            {
                ViewBag.Style = "height:auto;";
            }
            return View();
        }
        public JsonResult Process()
        {
            ModifyOpenRegister mor = new ModifyOpenRegister();
            mor.Insert();
            return Json("true", JsonRequestBehavior.AllowGet);
        }
        public JsonResult Show()
        {
            ModifyOpenRegister mor = new ModifyOpenRegister();
            if(mor.CheckStatus())
            {
                return Json("button",JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("list", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
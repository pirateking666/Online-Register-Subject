using SoftwareTechnology.Areas.Student.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Student.Controllers
{
    public class RegisterClassController : Controller
    {
        // GET: Student/RegisterClass
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 3)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.Schedule = "menu-style";
            ViewBag.RegisterClass = "active-menu";
            new ModifyClass().ChangeStatusClass();
            new ModifyClass().ChangeStatusClassByNumberOfStudent();
            new ModifyClass().ChangeStatusClassIfItEnd();
            new ModifyClass().ChangeStatusClassRe();
            new ModifyClass().ChangeStatusIfTeacherNotReceive();
            new ModifyClass().ChangeStatusIfClassReEnd();
            ViewBag.ListClassRe = new ModifyClass().GetListClassRe();
            ViewBag.ListSubjectDrop = new SelectList(new ModifySubjectProgram().GetList((int)Session["branchID"]), "subjectID", "name");
            ViewBag.ListDay = new SelectList(new ModifyDay().GetList(), "ID", "Name");
            ViewBag.ListTime = new SelectList(new ModifyTime().GetList(), "ID", "Name");
            ViewBag.ListRoom = new SelectList(new ModifyRoom().GetList(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public JsonResult InsertClass(ManagerClassRe model)
        {
            return Json(new ManagerClassRe().InsertClass(model, (int)Session["branchID"]), JsonRequestBehavior.AllowGet);
        }
    }
}
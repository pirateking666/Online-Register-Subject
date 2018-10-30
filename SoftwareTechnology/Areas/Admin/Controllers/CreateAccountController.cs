using SoftwareTechnology.Areas.Admin.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Admin.Controllers
{
    public class CreateAccountController : Controller
    {
        // GET: Admin/CreateAccount
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.CreateAcc = "active-menu";
            ViewBag.OpenRegis = "menu-style";
            ViewBag.ListRegis = "menu-style";
            ViewBag.BranchList = new SelectList(new ModifyBranch().GetListBranch(), "ID", "Name");
            ViewBag.CourseList = new SelectList(new ModifyCourse().GetListCourse(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public JsonResult CreateAdminAccount(CreateAccount model)
        {
            CreateAdminAccount caa = new CreateAdminAccount();
            string result = caa.InsertAdminAccount(model.Admin.username, model.Admin.password, 1, model.Admin.name);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateTeacherAccount(CreateAccount model)
        {
            CreateTeacherAccount cta = new CreateTeacherAccount();
            return Json(cta.InsertTeacherAccount(model.Teacher), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateStudentAccount(CreateAccount model)
        {
            CreateStudentAccount csa = new CreateStudentAccount();
            return Json(csa.InsertStudentAccount(model.Student), JsonRequestBehavior.AllowGet);
        }
    }
}
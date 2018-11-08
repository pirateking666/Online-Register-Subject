using SoftwareTechnology.Areas.Student.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Student.Controllers
{
    public class ScheduleManagerController : Controller
    {
        // GET: Student/ScheduleManager
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 3)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "menu-style";
            ViewBag.Schedule = "active-menu";
            ViewBag.RegisterClass = "menu-style";
            new ModifyClass().ChangeStatusClass();
            new ModifyClass().ChangeStatusClassByNumberOfStudent();
            new ModifyClass().ChangeStatusClassIfItEnd();
            new ModifyClass().ChangeStatusClassRe();
            new ModifyClass().ChangeStatusIfTeacherNotReceive();
            new ModifyClass().ChangeStatusIfClassReEnd();
            ViewBag.ScheduleClass = new ModifyClass().GetListScheduleByStudentID(new ModifyStudent().GetIDByStudentUsername((string)Session["username"]), (int)Session["branchID"]);
            ViewBag.Class = new ModifyClass().GetListByBranchIDAndCourseID((int)Session["branchID"], (int)Session["courseID"]);
            ViewBag.ClassRe = new ModifyClass().GetListByBranchID((int)Session["branchID"]);
            ViewBag.StudentDetail = new ModifyStudentDetail().GetListByStudentID(new ModifyStudent().GetIDByStudentUsername((string)Session["username"]));
            return View();
        }
        public JsonResult Join(int ClassID, int DayID, int TimeID)
        {
            return Json(new JoinLeaveClass().JoinClass(ClassID, (string)Session["username"], DayID, TimeID,(int)Session["branchID"]), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Leave(int ClassID)
        {
            return Json(new JoinLeaveClass().LeaveClass(ClassID, (string)Session["username"]), JsonRequestBehavior.AllowGet);
        }
    }
}
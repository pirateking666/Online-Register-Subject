using SoftwareTechnology.Areas.Teacher.Models;
using SoftwareTechnology.Models;
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
            new ModifyClass().ChangeStatusClass();
            new ModifyClass().ChangeStatusClassByNumberOfStudent();
            new ModifyClass().ChangeStatusClassIfItEnd();
            new ModifyClass().ChangeStatusClassRe();
            new ModifyClass().ChangeStatusIfTeacherNotReceive();
            new ModifyClass().ChangeStatusIfClassReEnd();
            ViewBag.ListClass = new ModifyClass().GetListScheduleByTeacherID(new ModifyTeacher().GetTeacherByUsername((string)Session["username"]).ID);
            ViewBag.ListSubjectDrop = new SelectList(new ModifySubjectProgram().GetList((int)Session["branchID"]), "subjectID", "name");
            ViewBag.ListDay = new SelectList(new ModifyDay().GetList(), "ID", "Name");
            ViewBag.ListTime = new SelectList(new ModifyTime().GetList(), "ID", "Name");
            ViewBag.ListRoom = new SelectList(new ModifyRoom().GetList(), "ID", "Name");
            ViewBag.ListStudent = new ModifyStudentDetail().GetListByTeacherID(new ModifyTeacher().GetTeacherByUsername((string)Session["username"]).ID);
            return View();
        }
        public JsonResult InsertClass(ManagerClass model)
        {
            //ViewBag.MessageReport = new CreateClass().ReturnMessageRegister(model.dayID, model.timeID, model.roomID);
            return Json(new ManagerClass().InsertClass(model, 1, (int)Session["branchID"], (string)Session["username"], 1), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteClass(int ClassID)
        {
            return Json(new ManagerClass().DeleteClassByID(ClassID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowUpdate(int ClassID)
        {
            Class c = new ModifyClass().GetClassByID(ClassID);
            if (c != null)
            {
                return Json(c.SubjectID + "-" + c.DayID + "-" + c.TimeID + "-" + c.RoomID, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("false", JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateClass(ManagerClass model)
        {
            return Json(new ManagerClass().UpdateClass(model,(int)Session["branchID"]),JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowListStudent(int classID)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}
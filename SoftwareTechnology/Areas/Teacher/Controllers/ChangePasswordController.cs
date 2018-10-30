using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Teacher.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: Teacher/ChangePassword
        public ActionResult Index()
        {
            if (Session["userName"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePass = "active-menu";
            ViewBag.Schedule = "menu-style";
            ViewBag.Accept = "menu-style";
            return View();
        }
        [HttpPost]
        public JsonResult ChangePasswordVerify(UpdateAccountModel model)
        {
            string username = Session["userName"].ToString();
            UpdateAccountModel uam = new UpdateAccountModel();
            model.username = username;
            string check = uam.ChangePassword(model);
            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}
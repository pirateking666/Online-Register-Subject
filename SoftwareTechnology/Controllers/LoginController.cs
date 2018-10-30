using SoftwareTechnology.Common;
using SoftwareTechnology.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareTechnology.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Home = "menu-style";
            ViewBag.Login = "active-menu";
            return View();
        }
        [HttpPost]
        public JsonResult VerifyLogin(LoginModel model)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();

            Md5Function md5Hash = new Md5Function();
            string psw = md5Hash.MD5HashFunction(model.passWord);

            Account loginAcc = db.Accounts.SingleOrDefault(x => x.UserName == model.userName && x.PassWord == psw);
            string result = "0";

            if (loginAcc != null)
            {
                Session["userName"] = loginAcc.UserName;
                if (loginAcc.PositionID == 1)
                {
                    Session["positionID"] = 1;
                    result = "Admin";
                }
                else if (loginAcc.PositionID == 2)
                {
                    Teacher temp = db.Teachers.SingleOrDefault(x => x.UserName == model.userName);
                    Session["positionID"] = 2;
                    Session["branchID"] = temp.BranchID;
                    result = "Teacher";
                }
                else if (loginAcc.PositionID == 3)
                {
                    Student temp = db.Students.SingleOrDefault(x => x.UserName == model.userName);
                    Session["positionID"] = 3;
                    Session["branchID"] = temp.BranchID;
                    Session["courseID"] = temp.CourseID;
                    result = "Student";
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index","Home","Home");
        }
    }
}
using SoftwareTechnology.Areas.Teacher.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Student.Models
{
    public class ManagerClassRe
    {
        public int subjectID { get; set; }
        public int dayID { get; set; }
        public int timeID { get; set; }
        public int roomID { get; set; }
        public int classID { get; set; }
        public string InsertClass(ManagerClassRe model, int branchID)
        {
            if (CheckOpenRegister())
            {
                List<ListClass> listClass = new ModifyClass().GetListClassForStudent();
                if (new ManagerClass().CheckExist(model.dayID, model.timeID, model.roomID, listClass))
                {
                    return new ManagerClass().ReturnMessageRegister(model.dayID, model.timeID, model.roomID, listClass);
                }
                else
                {
                    ModifyClass mc = new ModifyClass();
                    mc.InsertForClassRe(2, model.subjectID, model.dayID, model.timeID, model.roomID, branchID);
                    return "true";
                }
            }
            else
            {
                return "Đang trong thời gian đăng ký học kỳ chính";
            }
        }
        public bool CheckOpenRegister()
        {
            ModifyOpenRegister mor = new ModifyOpenRegister();
            if (mor.GetListByStatusID(3).Count() != 0)
            {
                if (DateTime.Now > mor.GetDayStartByStatusID(3) && DateTime.Now < mor.GetDayEndByStatusID(3))
                    return false;
                else
                    return true;
            }
            else
            {
                if (DateTime.Now.AddDays(91).Month == 8 || DateTime.Now.AddDays(91).Month == 12)
                    return false;
                else
                    return true;
            }
        }
    }
}
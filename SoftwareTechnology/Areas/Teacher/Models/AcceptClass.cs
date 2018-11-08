using SoftwareTechnology.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Teacher.Models
{
    public class AcceptClass
    {
        public string ReceiveClass(int ClassID, string username, int dayID, int timeID)
        {
            if(CheckSameSchedule(new ModifyTeacher().GetTeacherByUsername(username).ID, dayID, timeID))
            {
                SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
                Class c = db.Classes.SingleOrDefault(x => x.ID == ClassID);
                c.TeacherID = new ModifyTeacher().GetTeacherByUsername(username).ID;
                c.StatusID = 3;
                c.DayStart = c.DayStart.Value.AddDays(21);
                c.DayEnd = c.DayEnd.Value.AddDays(91);
                db.SaveChanges();
                return "true";
            }
            else
            {
                return "Lớp muốn nhận trùng ngày và giờ dạy";
            }
        }
        public bool CheckSameSchedule(int teacherID, int dayID, int timeID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            List<Class> listClass = db.Classes.Where(x => x.TeacherID == teacherID).ToList();
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].DayID == dayID && listClass[i].TimeID == timeID && listClass[i].StatusID == 3)
                    return false;
            }
            return true;
        }
    }
}
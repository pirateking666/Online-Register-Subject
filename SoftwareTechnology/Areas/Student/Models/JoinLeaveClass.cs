using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Student.Models
{
    public class JoinLeaveClass
    {
        public string JoinClass(int ClassID, string username, int dayID, int timeID, int branchID)
        {
            if (CheckSameSchedule(new ModifyStudent().GetIDByStudentUsername(username), dayID, timeID, branchID))
            {
                ModifyStudentDetail msd = new ModifyStudentDetail();
                msd.Insert(ClassID, new ModifyStudent().GetIDByStudentUsername(username));
                return "true";
            }
            else
            {
                return "Đăng ký bị trùng ngày và giờ học";
            }
        }
        public string LeaveClass(int classID, string username)
        {
            ModifyStudentDetail msd = new ModifyStudentDetail();
            msd.Delete(classID, new ModifyStudent().GetIDByStudentUsername(username));
            return "true";
        }
        public bool CheckSameSchedule(int studentID, int dayID, int timeID, int branchID)
        {
            List<ListClass> listClass = new ModifyClass().GetListScheduleByStudentID(studentID, branchID);
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].dayID == dayID && listClass[i].timeID == timeID && listClass[i].statusID != 5)
                    return false;
            }
            return true;
        }

    }
}
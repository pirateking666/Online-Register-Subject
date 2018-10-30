using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyClass
    {
        public List<ListClass> GetList()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5).Select(x => new ListClass { classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
    }
}
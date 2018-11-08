using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyStudentDetail
    {
        public List<StudentDetail> GetListByStudentID(int studentID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.StudentDetails.Where(x => x.StudentID == studentID).ToList();
        }
        public List<ListStudent> GetListForClass(int classID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.StudentDetails.Where(x => x.ClassID == classID).Select(x => new ListStudent { classID = x.ClassID, studentID = x.StudentID, studentName = x.Student.Name, country = x.Student.Country, birth = x.Student.Birth, gender = x.Student.Gender }).ToList();
        }
        public List<ListStudent> GetListByTeacherID(int teacherID)
        {
            List<Class> listClass = new SoftwareTechnologyDBContext().Classes.Where(x => x.TeacherID == teacherID).ToList();
            int[] classIDArray = new int[listClass.Count()];
            for (int i = 0; i < listClass.Count; i++)
            {
                classIDArray[i] = listClass[i].ID;
            }
            List<ListStudent> list = new SoftwareTechnologyDBContext().StudentDetails.Where(x => classIDArray.Contains(x.ClassID)).Select(x => new ListStudent { classID = x.ClassID, studentID = x.StudentID, studentName = x.Student.Name, country = x.Student.Country, birth = x.Student.Birth, gender = x.Student.Gender }).ToList();
            return list;
        }
        public int[] GetArrayClassIDByStudentID(int studentID)
        {
            List<StudentDetail> listSD = new SoftwareTechnologyDBContext().StudentDetails.Where(x => x.StudentID == studentID).ToList();
            int[] classIDArray = new int[listSD.Count()];
            for (int i = 0; i < listSD.Count(); i++)
            {
                classIDArray[i] = listSD[i].ClassID;
            }
            return classIDArray;
        }
        public void Insert(int classID, int studentID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            StudentDetail sd = new StudentDetail();
            sd.ID = 0;
            sd.ClassID = classID;
            sd.StudentID = studentID;
            db.StudentDetails.Add(sd);
            db.SaveChanges();
        }
        public void Delete(int classID, int studentID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            StudentDetail sd = db.StudentDetails.SingleOrDefault(x => x.StudentID == studentID && x.ClassID == classID);
            db.StudentDetails.Remove(sd);
            db.SaveChanges();
        }
    }
}
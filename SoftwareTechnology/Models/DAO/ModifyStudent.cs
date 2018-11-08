using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyStudent
    {
        public int GetNextID()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return (db.Students.Count() + 1);
        }
        public int GetIDByStudentUsername(string username)
        {
            return new SoftwareTechnologyDBContext().Students.SingleOrDefault(x => x.UserName == username).ID;
        }
        public void Insert(string name, DateTime birth, string gender, string country, string address, string username, int courseID, int branchID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Student s = new Student();
            s.ID = GetNextID();
            s.Birth = birth;
            s.Gender = gender;
            s.Country = country;
            s.Address = address;
            s.UserName = username;
            s.CourseID = courseID;
            s.BranchID = branchID;
            s.Name = name;
            db.Students.Add(s);
            db.SaveChanges();

        }
    }
}
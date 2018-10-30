using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyTeacher
    {
        public int GetNextID()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Teachers.Count();
        }
        public void Insert(string name, string gender, string country, int branchID, DateTime birth, string phone, string username)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Teacher t = new Teacher();
            t.Name = name;
            t.ID = GetNextID();
            t.Gender = gender;
            t.Country = country;
            t.BranchID = branchID;
            t.Birth = birth;
            t.Phone = phone;
            t.UserName = username;
            db.Teachers.Add(t);
            db.SaveChanges();
        }
    }
}
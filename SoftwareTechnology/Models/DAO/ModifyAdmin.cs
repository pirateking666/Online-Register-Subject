using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyAdmin
    {
        public void Insert(int ID, string name, string username)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Admin a = new Admin();
            a.ID = ID;
            a.Name = name;
            a.UserName = username;
            db.Admins.Add(a);
            db.SaveChanges();
        }
        public int GetNextID()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Admins.Count() + 1;
        }
    }
}
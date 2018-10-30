using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyOpenRegister
    {
        public List<OpenRegister> GetList()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.OpenRegisters.ToList();
        }
        public void Insert()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            OpenRegister or = new OpenRegister();
            DateTime dt = DateTime.Now;
            or.StatusID = 3;
            or.ID = GetNextID();
            or.DayStart = dt;
            or.DayEnd = dt.AddDays(5);
            db.OpenRegisters.Add(or);
            db.SaveChanges();
        }
        public void Update(int ID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            OpenRegister or = db.OpenRegisters.SingleOrDefault(x => x.ID == ID);
            or.StatusID = 4;
            db.SaveChanges();
        }
        public int GetNextID()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.OpenRegisters.Count() + 1;
        }
        public bool CheckStatus()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            List<OpenRegister> list = db.OpenRegisters.ToList();
            if (list.Count() != 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].StatusID == 3)
                    {
                        if (CheckDayExpired(list[i]))
                        {
                            Update(list[i].ID);
                            return true;
                        }
                        else
                        {

                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool CheckDayExpired(OpenRegister or)
        {
            DateTime dt = DateTime.Now;
            if (or.DayEnd < dt)
            {
                return true;
            }
            else
                return false;
        }
    }
}
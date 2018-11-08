using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyDay
    {
        public List<Day> GetList()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Days.ToList();
        }
        public string GetDayByID(int dayID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Day d = db.Days.SingleOrDefault(x => x.ID == dayID);
            return d.Name;
        }
    }
}
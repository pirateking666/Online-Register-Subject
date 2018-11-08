using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyTime
    {
        public List<Time> GetList()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Times.ToList();
        }
        public string GetTimeByID(int timeID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Time t = db.Times.SingleOrDefault(x => x.ID == timeID);
            return t.Name;
        }
    }
}
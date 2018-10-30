using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyCourse
    {
        public List<Course> GetListCourse()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            DateTime dt = DateTime.Now;
            return db.Courses.Where(x => x.BeginYear == dt.Year || x.BeginYear == (dt.Year - 1) || x.BeginYear == (dt.Year - 2) || x.BeginYear == (dt.Year - 3)).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyBranch
    {
        public List<Branch> GetListBranch()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            List<Branch> list = db.Branches.Where(x => x.ID != 0).ToList();
            return list;
        }

    }
}
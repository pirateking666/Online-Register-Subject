using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ListSubject
    {
        public string name { get; set; }
        public int credit { get; set; }
        public int subjectID { get; set; }
        public int branchID { get; set; }
        public int semesterID { get; set; }

    }
}
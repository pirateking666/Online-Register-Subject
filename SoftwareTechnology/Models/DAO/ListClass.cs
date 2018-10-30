using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ListClass
    {
        public string classType { get; set; }
        public string course { get; set; }
        public string branch { get; set; }
        public string subject { get; set; }
        public string day { get; set; }
        public string time { get; set; }
        public string room { get; set; }
        public string teacher { get; set; }
        public string status { get; set; }
        public int numberOfStudent { get; set; }
        public int classTypeID { get; set; }
        public int courseID { get; set; }
        public int branchID { get; set; }
        public int subjectID { get; set; }
        public int dayID { get; set; }
        public int timeID { get; set; }
        public int roomID { get; set; }
        public int teacherID { get; set; }
        public int statusID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ListStudent
    {
        public int studentID { get; set; }
        public int classID { get; set; }
        public string studentName { get; set; }
        public string gender { get; set; }
        public DateTime birth { get; set; }
        public string country { get; set; }
    }
}
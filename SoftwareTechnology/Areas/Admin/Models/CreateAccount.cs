using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Admin.Models
{
    public class CreateAccount
    {
        public CreateAdminAccount Admin { get; set; }
        public CreateTeacherAccount Teacher { get; set; }
        public CreateStudentAccount Student { get; set; }
    }
}
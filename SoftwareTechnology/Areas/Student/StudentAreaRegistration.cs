﻿using System.Web.Mvc;

namespace SoftwareTechnology.Areas.Student
{
    public class StudentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Student";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Student_default",
                "Student/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] {"SoftwareTechnology.Areas.Student.Controllers"}
            );
        }
    }
}
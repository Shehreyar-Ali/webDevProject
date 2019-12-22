using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Courses
    {
        public string courseID { get; set; }
        public string Major_majorID { get; set; }
        public string courseName { get; set; }
        public string courseInstructor { get; set; }
    }
}
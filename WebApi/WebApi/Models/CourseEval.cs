using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CourseEval
    {
        public string ID { get; set; }
        public string Student_stuID { get; set; }
        public string Courses_courseID { get; set; }
        public Nullable<int> question1 { get; set; }
        public Nullable<int> question2 { get; set; }
        public Nullable<int> question3 { get; set; }
        public Nullable<int> question4 { get; set; }
        public Nullable<int> question5 { get; set; }
        public Nullable<int> question6 { get; set; }
        public Nullable<int> question7 { get; set; }
        public Nullable<int> question8 { get; set; }
        public Nullable<int> question9 { get; set; }
        public Nullable<int> question10 { get; set; }
    }
}
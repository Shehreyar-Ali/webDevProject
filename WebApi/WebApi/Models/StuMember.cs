using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class StuMember
    {
        public int id { get; set; }
        public string loginStu { get; set; }
        public string passwordStu { get; set; }
    }
}
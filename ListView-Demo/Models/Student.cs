using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView_Demo.Models
{
    internal class Student
    {

        public int Index { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double GPA { get; set; }
        public int      Status { get; set; }
        public bool     Gender { get; set; }
        public string   BirthDay { get; set; }
        public string   Class { get; set; }
        public string   Major { get; set; }

    }
}

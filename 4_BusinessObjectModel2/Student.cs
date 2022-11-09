 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectModel
{
       
        public  class Student 
    {
       
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime BornDate { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
    }
    
    public class HighSchoolStudents :Student
    {
         public String SchoolName { get; set; }
         public DateTime DateOfEnrollment { get; set; }
    }
    public class FaculltyStudents : Student
    {
         public String FacultyName { get; set; }
         public int Generation { get; set; }
    }
}


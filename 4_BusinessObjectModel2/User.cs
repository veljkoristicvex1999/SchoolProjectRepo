 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectModel
{
       
        public  class User 
    {       
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime BornDate { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public List<UserRoles> Roles { get; set; }
        public String Password { get; set; }
    }
    
    public class HighSchoolStudents :User
    {
         public String SchoolName { get; set; }
         public DateTime DateOfEnrollment { get; set; }
    }
    public class FaculltyStudents : User
    {
         public String FacultyName { get; set; }
         public int Generation { get; set; }
    }
    public class Professor : User { }
    public class Admin : User { }
}


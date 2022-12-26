using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LayeredSolution.ViewModels
{
    public class ErrorsViewModel
    {
        
        [Key]
        public int Id_Eror;
        public String Er_Name { get; set; }
        public String Er_LastName { get; set; }
        public String Er_Email { get; set; }
        public String Er_Password { get; set; }
        public String Er_PhoneNumber { get; set; }
        public String Er_Address { get; set; }
        public string Er_Subject { get; set; }
        public String Er_HoursPerWeek { get; set; }
        public String Er_SchoolName { get; set; }
        public String Er_FacultyName { get; set; }
        public String Er_Generation { get; set; }
        public String Er_Roles { get; set; }
        
    }
}
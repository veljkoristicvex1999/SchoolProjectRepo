using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution.ViewModels
{
    public class HighSchoolViewModel : UserViewModel
    {
        public String SchoolName { get; set; }
        public DateTime DateOfEnrollment { get; set; }
    }
}
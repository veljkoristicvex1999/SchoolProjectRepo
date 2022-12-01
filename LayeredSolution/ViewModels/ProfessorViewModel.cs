using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution.ViewModels
{
    public class ProfessorViewModel :UserViewModel
    {
        public  string Subject { get; set; }
        public int HoursPerWeek { get; set; }
    }
}
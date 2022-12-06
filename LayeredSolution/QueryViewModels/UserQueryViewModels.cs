using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution.QueryViewModels
{
    public class UserQueryViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public string Address { get; set; }
    }
}
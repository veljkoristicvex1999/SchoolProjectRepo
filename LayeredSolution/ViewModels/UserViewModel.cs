using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution.ViewModels
{
    public class UserViewModel : ErrorsViewModel // extends error wiew model
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime BornDate { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String Password { get; set; }
        public bool isReadOnly { get; set; }
        public String ShowButton { get; set; }
      public List<UserRoles> Roles {get;set;}
    }
}
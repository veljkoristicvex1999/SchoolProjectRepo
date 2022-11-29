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
}


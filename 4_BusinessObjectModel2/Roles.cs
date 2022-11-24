using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObjectModel
{
    public class Roles
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        public List<UserRoles> UserRoles { get; set; }

        //list user roles
    }
}

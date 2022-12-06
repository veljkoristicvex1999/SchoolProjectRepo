using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectModel

{
     public class UserRoles
    {
        public int Id { get; set; }
        public User user;
        public int RoleId { get; set; }
        public Roles roles;
        //trebas da povuces user role i da napunis listu i userrole tjj da uradis join svega
        //pomocu include spajamo 
        //overide getall u user repo kako bi pribavili role iz ostalih 
        //add range kad se dodaj jer mora da dodaje u dve tabele istovremeno //treba ti kontoler za adminna i profesora kao i modela klase
        // treba ti jos uvek type
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BusinessObjectModel
{
    public  class Login
    {
        public String Email { get; set; 
        }
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}

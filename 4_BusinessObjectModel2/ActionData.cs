using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectModel
{
    public class ActionData
    {
        public int Id_Action { get; set; }
        public int Id {get;set; }
        public String CurrentUser { get; set; }
        public String Action { get; set; }
        public DateTime ActionTime { get; set; }
        public String Role { get; set; }
    }
}

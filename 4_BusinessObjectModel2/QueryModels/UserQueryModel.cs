using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessObjectModel.QueryModels
{
    public class UserQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BornDate { get; set; }
        public string Address { get; set; }
    }
}
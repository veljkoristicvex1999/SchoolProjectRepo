using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class RolesRepository : IRolesRepository
    {
        private TuxContext db;
        public RolesRepository(TuxContext db) 
        {
            this.db = db;
        }
        public List<Roles> getAllRoles()
        {
            return db.Roles.ToList();
        }
    }
}

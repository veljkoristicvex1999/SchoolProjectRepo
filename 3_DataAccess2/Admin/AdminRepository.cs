using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(TuxContext db) : base(db)
        {
             
        }

        public Admin findByEmail(string email)
        {   
            return table.Where(a => a.Email == email).First();
            
        }

    }
}

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
        public override IEnumerable<Admin> GetAllStudents()
        {
            return table.SqlQuery("  select * from ((t_users INNER JOIN t_user_roles ON t_users.Id = t_user_roles.Id) INNER JOIN t_roles ON t_roles.RoleId = t_user_roles.RoleId) where BillingDetailType = 'Admin'");

        }
    }
}

using BusinessObjectModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RolesService : IRolesService
    {
        private IRolesRepository IRolesRepository;
        public RolesService(IRolesRepository IRolesRepository)
        {
            this.IRolesRepository = IRolesRepository;
        }
        public List<Roles> getAllRoles()
        {
            return IRolesRepository.getAllRoles();
        }
    }
}

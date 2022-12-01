using BusinessObjectModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminService : GenericService<Admin>, IAdminService

        
    {
        private IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository) :base(adminRepository) 

        {
            this._adminRepository = adminRepository;
        }

        public Admin findByEmail(string email)
        {
            return _adminRepository.findByEmail(email);
        }
    }
}

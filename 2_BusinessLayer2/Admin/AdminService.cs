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
        private IAdminRepository IAdminRepository;
        public AdminService(IAdminRepository IAdminRepository) :base(IAdminRepository) 

        {
            this.IAdminRepository = IAdminRepository;
        }
    }
}

using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAdminService : IGenericService<Admin>
    {
        Admin findByEmail(String email);
    }
}

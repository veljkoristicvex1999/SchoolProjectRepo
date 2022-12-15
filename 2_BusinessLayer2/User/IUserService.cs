using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUserService : IGenericService<User>
    {
        User FindStudentByCredentials(String email, String password);
        
    }
}

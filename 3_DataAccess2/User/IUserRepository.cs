using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserRepository  : IGenericRepository<User>
    {
        User FindStudentByCredentials(String email, String password);
    }
}

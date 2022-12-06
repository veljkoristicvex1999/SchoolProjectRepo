using BusinessObjectModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService : GenericService<User>, IUserService
    {
        private IUserRepository IUserRepository;
        public UserService(IUserRepository IUserRepository) : base(IUserRepository)
        {
            this.IUserRepository = IUserRepository;
        }
        public User FindStudentByCredentials(string email, string password)
        {
            return IUserRepository.FindStudentByCredentials(email, password);
        }
    }
}

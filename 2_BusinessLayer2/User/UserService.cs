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
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this._userRepository = userRepository;
        }

       

        public User FindStudentByCredentials(string email, string password)
        {
            return _userRepository.FindStudentByCredentials(email, password);
        }
    }
}

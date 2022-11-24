using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TuxContext db) : base(db)
        {

        }
         public User FindStudentByCredentials(string email, string password)
        {
            return db.Users.Include("Roles").Where(a =>( a.Email.Equals(email)) && (a.Password.Equals(password))).FirstOrDefault();
        }

        
    }
}



using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAllStudents();

        // void  Create(T Student, List<UserRoles> students);
        void Create(T Student);
        T FindStudent(object id);
        void Delete(object id);
        void Update(T student);
       
        
    }
}

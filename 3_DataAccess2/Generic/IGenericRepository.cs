

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
        void Create(T Student);
        T FindStudent(object id);
        void Delete(object id);
        void Update(T student);
        IEnumerable<T> GetAll();
        // we write this method because we need it in login contoler
        

       
        
    }
}

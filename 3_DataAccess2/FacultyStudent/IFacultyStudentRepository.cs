using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IFacultyStudentRepository : IGenericRepository<FaculltyStudents>
    {
        List<FaculltyStudents> search(String search);
        void Export(int id);
      
    }
}

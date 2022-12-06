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
        
        void Export(int id);
        FaculltyStudents findByEmail(String emal);
    }
}

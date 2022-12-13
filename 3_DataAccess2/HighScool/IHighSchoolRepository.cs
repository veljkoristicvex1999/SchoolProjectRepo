
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IHighSchoolRepository : IGenericRepository<HighSchoolStudents>
    {
       
       void Export(int id);
        HighSchoolStudents findByEmail(String email);
        List<HighSchoolStudents> Search(String search);
        List<HighSchoolStudents> GetAllStudents();
    }
}

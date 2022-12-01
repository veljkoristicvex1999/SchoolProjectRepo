
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
        List<HighSchoolStudents> search(String search);
       void Export(int id);
        HighSchoolStudents findByEmail(String email);
    }
}

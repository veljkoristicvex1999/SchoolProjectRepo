using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        List<Professor> Search(String search);
        Professor findByEmail(String email);
        List<Professor> GetAllStudents();
       
    }
}

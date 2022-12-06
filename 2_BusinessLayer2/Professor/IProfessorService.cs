using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProfessorService : IGenericService<Professor>
    {
        List<ProfessorQueryModel> GetAllStudents();
        List<ProfessorQueryModel> Search(string search);
        Professor findByEmail(String email);
     
    }
}

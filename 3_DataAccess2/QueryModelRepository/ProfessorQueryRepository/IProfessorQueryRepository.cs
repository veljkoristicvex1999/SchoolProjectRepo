using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IProfessorQueryRepository  :  IGenericRepository<ProfessorQueryModel>
    {
        List<ProfessorQueryModel> GetAllStudents();
        List<ProfessorQueryModel> Search(String search);
    }
}

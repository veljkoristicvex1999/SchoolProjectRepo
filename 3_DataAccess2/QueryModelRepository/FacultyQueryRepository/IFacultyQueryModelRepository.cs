using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IFacultyQueryModelRepository : IGenericRepository<FacultyQueryModel>
    {
        List<FacultyQueryModel> GetAllStudents();
        List<FacultyQueryModel> Search(String search);
     
    }
}

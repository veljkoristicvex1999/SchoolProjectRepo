using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IHighSchoolQueryRepository : IGenericRepository<HighSchoolQueryModel>
    {
        List<HighSchoolQueryModel> GetAllStudents();
        List<HighSchoolQueryModel> Search(String search);
    }
}

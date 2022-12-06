using BusinessObjectModel;
using LayeredSolution.QueryViewModels;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution
{
    public interface IHighScoolAppService : IGenericAppService<HighSchoolStudents, HighSchoolViewModel>
    {
        List<HighSchoolQueryViewModels> Search(string search);
        List<HighSchoolQueryViewModels> GetAllStudents();
        HighSchoolViewModel findByEmail(String email);

    }
}
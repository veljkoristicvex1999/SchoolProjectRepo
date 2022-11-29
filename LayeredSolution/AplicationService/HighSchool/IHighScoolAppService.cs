using BusinessObjectModel;
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
        List<HighSchoolViewModel> Search(string search);

    }
}
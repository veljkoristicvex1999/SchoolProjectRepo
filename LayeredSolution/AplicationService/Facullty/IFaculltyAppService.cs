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
    public interface IFaculltyAppService : IGenericAppService<FaculltyStudents, FaculltyViewModel>
    {
        List<FacultyQueryViewModel> GetAllStudents();
        List<FacultyQueryViewModel> Search(string search);
        FaculltyViewModel findByEmail(String email);
    }
}

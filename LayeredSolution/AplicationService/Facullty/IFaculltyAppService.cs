using BusinessObjectModel;
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
        List<FaculltyViewModel> Search(string search);
        FaculltyViewModel findByEmail(String email);
    }
}

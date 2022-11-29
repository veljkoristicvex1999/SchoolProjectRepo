using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution
{
    public interface IProfessorAppService : IGenericAppService<Professor, ProfessorViewModel>
    {
        List<ProfessorViewModel> Search(string search);

    }
}
using BusinessObjectModel;
using LayeredSolution.QueryViewModels;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution
{
    public interface IProfessorAppService : IGenericAppService<Professor, ProfessorViewModel>
    {
        List<ProfessorQueryViewModels> GetAllStudents();
        List<ProfessorQueryViewModels> Search(string search);
        ProfessorViewModel findByEmail(String email);
    }
}
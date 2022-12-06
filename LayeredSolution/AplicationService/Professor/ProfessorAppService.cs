using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using LayeredSolution.QueryViewModels;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution
{
    public class ProfessorAppService : GenericAppService<Professor, ProfessorViewModel>, IProfessorAppService
    {
        private IProfessorService _professorService;
        private IMapper mapper;

        public ProfessorAppService(IProfessorService _professorService, IMapper mapper) : base(_professorService, mapper)
        {
            this.mapper = mapper;
            this._professorService = _professorService;
        }

        public ProfessorViewModel findByEmail(string email)
        {
            var data = mapper.Map<Professor, ProfessorViewModel>(_professorService.findByEmail(email));
            return data;
        }

        public List<ProfessorQueryViewModels> GetAllStudents()
        {
            var data = mapper.Map<List<ProfessorQueryModel>, List<ProfessorQueryViewModels>>(_professorService.GetAllStudents());
            return data;
        }

        public List<ProfessorQueryViewModels> Search(string search)
        {
            var data = mapper.Map<List<ProfessorQueryModel>, List<ProfessorQueryViewModels>>(_professorService.Search(search));
            return data;
        }

    }
}


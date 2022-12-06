using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution
{
    public class FaculltyAppService : GenericAppService<FaculltyStudents, FaculltyViewModel>, IFaculltyAppService
    {
      
        private IFacultyStudentService _facultyStudentService;
        private IMapper mapper;

        public FaculltyAppService(IFacultyStudentService facultyStudentService, IMapper mapper) : base(facultyStudentService, mapper)
        {           
            this.mapper = mapper;
            this._facultyStudentService = facultyStudentService;
        }

        public FaculltyViewModel findByEmail(string email)
        {
            var data = mapper.Map<FaculltyStudents, FaculltyViewModel>(_facultyStudentService.findByEmail(email));
            return data;
        }

        public List<FaculltyViewModel> Search(string search)
        {
            var data = mapper.Map<List<FaculltyStudents>, List<FaculltyViewModel>>(_facultyStudentService.Search(search));
            return data;
        }
    }
}
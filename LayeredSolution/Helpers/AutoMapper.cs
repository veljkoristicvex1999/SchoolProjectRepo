using AutoMapper;
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
    public static  class AutoMapper 
    {

        public static IMapper MapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                    //Create all maps here
                    cfg.CreateMap<FaculltyStudents, FaculltyViewModel>();
                cfg.CreateMap<HighSchoolStudents, HighSchoolViewModel>();
                cfg.CreateMap<Professor, ProfessorViewModel>();
                cfg.CreateMap<Admin, AdminViewModel>();
                cfg.CreateMap<HighSchoolQueryModel, HighSchoolQueryViewModels>();
                cfg.CreateMap<FacultyQueryModel, FacultyQueryViewModel>();
                cfg.CreateMap<ProfessorQueryModel, ProfessorQueryViewModels>();
                cfg.ValidateInlineMaps = false;
            });
             IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
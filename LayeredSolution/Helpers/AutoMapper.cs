using AutoMapper;
using BusinessObjectModel;
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
                cfg.ValidateInlineMaps = false;
            });
             IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
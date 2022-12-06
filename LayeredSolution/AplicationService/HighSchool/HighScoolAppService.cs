﻿using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using LayeredSolution.QueryViewModels;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution { 
    public class HighScoolAppService : GenericAppService<HighSchoolStudents, HighSchoolViewModel>, IHighScoolAppService
    {
        private IHighSchoolService _highSchoolStudentService;
        private IMapper mapper;

        public HighScoolAppService(IHighSchoolService _highSchoolStudentService, IMapper mapper) : base(_highSchoolStudentService, mapper)
        {
            this.mapper = mapper;
            this._highSchoolStudentService = _highSchoolStudentService;
        }

        public HighSchoolViewModel findByEmail(string email)
        {
            var data = mapper.Map<HighSchoolStudents,HighSchoolViewModel>(_highSchoolStudentService.findByEmail(email));
            return data;
        }

        public List<HighSchoolQueryViewModels> GetAllStudents()
        {
            var data = mapper.Map<List<HighSchoolQueryModel>, List<HighSchoolQueryViewModels>>(_highSchoolStudentService.GettAllStudents());
            return data;
        }

        public List<HighSchoolQueryViewModels> Search(string search)
        {
            var data = mapper.Map<List<HighSchoolQueryModel>, List<HighSchoolQueryViewModels>>(_highSchoolStudentService.Search(search));
            return data;
        }

    }
}
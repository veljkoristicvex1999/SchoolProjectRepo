using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using LayeredSolution.QueryViewModels;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public override HighSchoolViewModel Validate(HighSchoolViewModel model)
        {
         //   var highSchoolViewModel = mapper.Map<HighSchoolStudents, HighSchoolViewModel>(model);

            if (!Regex.IsMatch(model.Name, "^[a-zA-Z]+$"))
            {

                model.Er_Name += " Can not have anything except numbers in your name";
                return model;
            }
            if (!Regex.IsMatch(model.LastName, "^[a-zA-Z]+$"))
            {
                model.Er_LastName += "Can not have anything except letters in your lastName";
                return model;
            }
            if (!Regex.IsMatch(model.PhoneNumber, "^[0-9 ]+$"))
            {
                model.Er_PhoneNumber += "Can not have anything except numbers in your Phone number";
                return model;
            }
            if (!model.PhoneNumber.ToString().StartsWith("06"))
            {
                model.Er_PhoneNumber += " your mobile phone must start with 06... in right format";
                return model;
            }
            if ((model.PhoneNumber.ToString().Length < 9) || (model.PhoneNumber.ToString().Length > 15))
            {
                model.Er_PhoneNumber += " number size is to long or to short";
                return model;
            }
      
   
            if (!(model.Email.Contains("@") && model.Email.EndsWith(".com") && !model.Email.StartsWith("@")))
            {
                model.Er_Email = "Your mail have to be in right format";
                return model;
            }

            if (!Regex.IsMatch(model.Password, @"^[A-Za-z]+\d+.*$"))
            {
                model.Er_Password = "Your password should contain letters, numbers and special charachters";
                return model;
            }
            return model;

        }
    }
}
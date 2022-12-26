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
using System.Web.Helpers;
using System.Web.WebPages;

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

        public List<FacultyQueryViewModel> Search(string search)
        {
            var data = mapper.Map<List<FacultyQueryModel>, List<FacultyQueryViewModel>>(_facultyStudentService.Search(search));
            return data;
        }

        List<FacultyQueryViewModel> IFaculltyAppService.GetAllStudents()
        {
            var data = mapper.Map<List<FacultyQueryModel>, List<FacultyQueryViewModel>>(_facultyStudentService.GetAllStudents());
            return data;
        }

        public override FaculltyViewModel Validate(FaculltyViewModel model)
        {
           

            if (!Regex.IsMatch(model.Name, "^[a-zA-Z]+$"))
            {

                model.Er_Name+= " Can not have anything except numbers in your name";
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
            if ((Regex.IsMatch(model.Generation.ToString(), "^[a-zA-Z]+$")) || model.Generation.ToString().Length != 4)
            {
                model.Er_Generation = "Your generation should be in right format";
                return model;
            }
            if (model.Generation < 1920 || model.Generation > 2010)
            {
                model.Er_Generation = "You should give a right Generation for new users";
                return model;
            }
            if (!Regex.IsMatch(model.FacultyName.ToString(), "^[a-zA-Z]+$"))
            {
                model.Er_FacultyName = "You can not have anything except numbers in your lastName";
                return model;
            }
            if (!(model.Email.Contains("@") && model.Email.EndsWith(".com") && !model.Email.StartsWith("@")))
            {
                model.Er_Email = "Your mail have to be in right format";
                return model;
            }
            
            if (!Regex.IsMatch(model.Password, @"^[A-Za-z]+\d+.*$")) {
                model.Er_Password = "Your password should contain letters, numbers and special charachters";
                return model;
            }
           

            return model;
            
        }
    }
}
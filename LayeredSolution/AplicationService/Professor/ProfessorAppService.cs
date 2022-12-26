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
        //view modekl valdirAJ
        //MAPIRAJ ROLE I KORISTI VIEV MODEL NA CONOLERTU 
        public override ProfessorViewModel Validate(ProfessorViewModel professorViewModel)
        {
           // var professorViewModel = mapper.Map<Professor, ProfessorViewModel>(model);

            if (!Regex.IsMatch(professorViewModel.Name, "^[a-zA-Z]+$"))
            {

                professorViewModel.Er_Name += " Can not have anything except numbers in your name";
                return professorViewModel;
            }
            if (!Regex.IsMatch(professorViewModel.LastName, "^[a-zA-Z]+$"))
            {
                professorViewModel.Er_LastName += "Can not have anything except letters in your lastName";
                return professorViewModel;
            }
            if (!Regex.IsMatch(professorViewModel.PhoneNumber, "^[0-9 ]+$"))
            {
                professorViewModel.Er_PhoneNumber += "Can not have anything except numbers in your Phone number";
                return professorViewModel;
            }
            if (!professorViewModel.PhoneNumber.ToString().StartsWith("06"))
            {
                professorViewModel.Er_PhoneNumber += " your mobile phone must start with 06... in right format";
                return professorViewModel;
            }
            if ((professorViewModel.PhoneNumber.ToString().Length < 9) || (professorViewModel.PhoneNumber.ToString().Length > 15))
            {
                professorViewModel.Er_PhoneNumber += " number size is to long or to short";
                return professorViewModel;
            }
            if (!Regex.IsMatch(professorViewModel.HoursPerWeek.ToString(), "^[0-9 ]+$"))
            {
                professorViewModel.Er_HoursPerWeek = "Hours per week should be number ";
                return professorViewModel;
            }


            if (!(professorViewModel.Email.Contains("@") && professorViewModel.Email.EndsWith(".com") && !professorViewModel.Email.StartsWith("@")))
            {
                professorViewModel.Er_Email = "Your mail have to be in right format";
                return professorViewModel;
            }

            if (!Regex.IsMatch(professorViewModel.Password, @"^[A-Za-z]+\d+.*$"))
            {
                professorViewModel.Er_Password = "Your password should contain letters, numbers and special charachters";
                return professorViewModel;
            }
            return professorViewModel;

        }
    }
}


using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
    public class ProfessorController : GenericController<Professor, ProfessorViewModel>
    {
        private IRolesService _rolesService;
       private IProfessorAppService _professorAppService;
        private IMapper mapper;

       public ProfessorController(IProfessorAppService _professorAppService, IRolesService rolesService, IMapper mapper) : base(_professorAppService)
        {
            this.mapper = mapper;
            this._rolesService = rolesService;
            this._professorAppService = _professorAppService;
        }
        [Authorize(Roles = "Professor, Admin")]
        public override ActionResult Index()
        {

            var model = _professorAppService.GetAllStudents();
            return View(model);
        }
         [Authorize(Roles = "Admin")]
        public override ActionResult Create(Professor student)
        {
            List<UserRoles> UserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = student.Id,
                RoleId = _rolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "Professor").RoleId

            };
            UserRoles.Add(userRole);
            student.Roles = UserRoles;
            _professorAppService.Create(student);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Search(String Search)
        {
            var model = _professorAppService.Search(Search.Trim());
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public override ActionResult Edit(int id)
        {


            var data = _professorAppService.findStudent(id);
            data.isReadOnly = false;
            if (data != null)
            {
                return View("Edit", data);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public override ActionResult Details(int id)
        {
            var data = _professorAppService.findStudent(id);
            data.isReadOnly = true;
            return View("Edit", data);
        }


        public override ActionResult Delete(int id)
        {
            var model = _professorAppService.findStudent(id);
            return View(model);
        }
        public ActionResult UserProfile()
        {
            var data = _professorAppService.findByEmail(User.Identity.Name);
            return View(data);
        }

    }
}

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
        private IGenericService<ActionData> _actionDataService;
        private IRolesService _rolesService;
       private IProfessorAppService _professorAppService;
        private IMapper mapper;

       public ProfessorController(IProfessorAppService _professorAppService, IRolesService rolesService, IMapper mapper, IGenericService<ActionData> _actionDataService) : base(_professorAppService)
        {
            this._actionDataService = _actionDataService;
            this.mapper = mapper;
            this._rolesService = rolesService;
            this._professorAppService = _professorAppService;
        }
        [Authorize(Roles = "Professor, Admin")]
        public  ActionResult Index()
        {

            var model = _professorAppService.GetAllStudents();
            return View(model);
        }

         [Authorize(Roles = "Admin")]
        public override ActionResult Create(ProfessorViewModel student)
        {
            var studentVievModel = _professorAppService.Validate(student);
            var ok = CheckError(studentVievModel);
            if (ok) { 
            List<UserRoles> UserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = student.Id,
                RoleId = _rolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "Professor").RoleId

            };
            UserRoles.Add(userRole);
            student.Roles = UserRoles;
            _professorAppService.Create(student);
            ActionData data = SetActionData();
            data.Id = student.Id;
            _actionDataService.Create(data);
            return RedirectToAction("Index");
            }
            else
            {
                return View("Create", studentVievModel);
            }
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

        public ActionData SetActionData()
        {
            ActionData action = new ActionData();
            action.Action = this.ControllerContext.RouteData.Values["action"].ToString();
            action.Role = this.ControllerContext.RouteData.Values["controller"].ToString();
            action.ActionTime = DateTime.Now;
            action.CurrentUser = User.Identity.Name;
            return action;
        }

        public override ActionResult Delete(int id, FormCollection formCollection)
        {
            ActionData data = SetActionData();
            data.Id = id;
            _actionDataService.Create(data);
            return base.Delete(id, formCollection);
        }

        public override ActionResult Edit(ProfessorViewModel student)
        {
            var studentVievModel = _professorAppService.Validate(student);
            var ok = CheckError(studentVievModel);
            if (ok)
            {
                ActionData data = SetActionData();
                data.Id = student.Id;
                _actionDataService.Create(data);
                return base.Edit(student);
            }
            else
            {
                return View("Edit", studentVievModel);
            }
        }
        public bool CheckError(ProfessorViewModel professor)
        {
            if ( professor.Er_Name == null && professor.Er_LastName == null && professor.Er_Email == null && professor.Er_Password == null && professor.Er_PhoneNumber == null &&  professor.Er_Subject == null && professor.Er_HoursPerWeek == null && professor.Er_Address == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

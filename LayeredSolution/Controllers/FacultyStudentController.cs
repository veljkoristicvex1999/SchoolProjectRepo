using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using LayeredSolution.ViewModels;

namespace LayeredSolution.Controllers
{
    public class FacultyStudentController : GenericController<FaculltyStudents, FaculltyViewModel>

    {
        private IGenericService<ActionData> _actionDataService;
        private IRolesService _rolesService;
        private IFaculltyAppService _faculltyAppService;
        private IMapper mapper;
        public FacultyStudentController(IFaculltyAppService _faculltyAppService, IRolesService _rolesService, IMapper mapper, IGenericService<ActionData> _actionDataService) : base(_faculltyAppService)
        {
            this.mapper = mapper;
            this._actionDataService = _actionDataService;
            this._rolesService = _rolesService;
            this._faculltyAppService = _faculltyAppService;
        }


        [Authorize(Roles = "Professor,Admin")]
        public ActionResult Search(String Search)
        {
            var model = _faculltyAppService.Search(Search.Trim());
            return View(model);
        }

        //[Authorize(Roles = "Professor,Admin")]
        //public ActionResult Export(int id)
        //{
        //    var model = faculltyAppService.findStudent(id);
        //    if (model != null)
        //    {
        //        faculltyAppService.Export(id);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("NotFound");
        //}

        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Edit(int id)
        {
            var data = _faculltyAppService.findStudent(id);
            data.isReadOnly = false;
            if (data != null)
            {
                return View("Edit", data);
            }
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Details(int id)
        {
            var data = _faculltyAppService.findStudent(id);
            data.isReadOnly = true;
            data.ShowButton = "disabled";
            return View("Edit", data);
        }


        [Authorize(Roles = "Facullty,Professor,Admin")]
        public ActionResult Index()
        {

            var data = _faculltyAppService.GetAllStudents();
            return View(data);
        }


        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Create(FaculltyViewModel student)
        {

            var studentVievModel = _faculltyAppService.Validate(student);
            var ok  =  CheckError(studentVievModel);

            if (ok)
            {
                List<UserRoles> UserRoles = new List<UserRoles>();
                UserRoles userRole = new UserRoles()
                {
                    Id = student.Id,
                    RoleId = _rolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "Facullty").RoleId

                };

                UserRoles.Add(userRole);
                student.Roles = UserRoles;
                _faculltyAppService.Create(student);
                // save data about action 
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

        [HttpGet]
        public override ActionResult Delete(int id)
        {
            var data = _faculltyAppService.findStudent(id);
            return View(data);
        }

        public ActionResult UserProfile()
        {
            var data = _faculltyAppService.findByEmail(User.Identity.Name);
            return View(data);
        }

        public override ActionResult Delete(int id, FormCollection formCollection)
        {
            ActionData data = SetActionData();
            data.Id = id;
            _actionDataService.Create(data);
            return base.Delete(id, formCollection);
        }

      

        public override ActionResult Edit(FaculltyViewModel student)
        {
            var studentVievModel = _faculltyAppService.Validate(student);
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

        public ActionData SetActionData()
        {

            ActionData action = new ActionData();
            action.Action = this.ControllerContext.RouteData.Values["action"].ToString();
            action.Role = this.ControllerContext.RouteData.Values["controller"].ToString();
            action.ActionTime = DateTime.Now;
            action.CurrentUser = User.Identity.Name;
            return action;
        }

        public bool CheckError(FaculltyViewModel fac)
        {
            if(fac.Er_Name==null && fac.Er_LastName==null && fac.Er_Email==null && fac.Er_Password == null && fac.Er_PhoneNumber == null && fac.Er_FacultyName == null && fac.Er_Generation == null && fac.Er_Subject == null && fac.Er_HoursPerWeek == null && fac.Er_Address == null)
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
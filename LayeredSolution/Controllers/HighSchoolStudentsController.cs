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
    public class HighSchoolStudentsController : GenericController<HighSchoolStudents, HighSchoolViewModel>
    {
        private IGenericService<ActionData> _actionDataService;
        private IHighScoolAppService _highScoolAppService;
        private IRolesService _rolesService;
        private IMapper mapper;
        
        public HighSchoolStudentsController(IHighScoolAppService _highScoolAppService, IRolesService _rolesService, IMapper mapper, IGenericService<ActionData> _actionDataService) :base(_highScoolAppService)
        {
            this._actionDataService = _actionDataService;
            this.mapper = mapper;
            this._highScoolAppService = _highScoolAppService;
            this._rolesService = _rolesService;
        }

        [Authorize(Roles = "Admin,Professor")]
        public ActionResult Search(String Search)
        {
            var model = _highScoolAppService.Search(Search.Trim());
            return View(model);
        }

        [Authorize(Roles = "Admin,Professor")]
        public override ActionResult Edit(int id)
        {
 
            var data = _highScoolAppService.findStudent(id);
            data.isReadOnly = false;
            if (data != null)
            {
                return View("Edit", data);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Professor")]
        public override ActionResult Details(int id)
        {          
            var data = _highScoolAppService.findStudent(id);
            data.isReadOnly = true;
            return View("Edit", data);
        }
    
        [Authorize(Roles = "HighSchool,Professor,Admin")]
        public  ActionResult Index()
        {
            var model = _highScoolAppService.GetAllStudents();          
            return View(model);
        }


        [Authorize(Roles = "Admin,Professor")]
        public override ActionResult Create(HighSchoolViewModel student)
        {

            var studentVievModel = _highScoolAppService.Validate(student);
            var ok = CheckError(studentVievModel);
            if (ok)
            {
                List<UserRoles> UserRoles = new List<UserRoles>();
                UserRoles userRole = new UserRoles()
                {
                    Id = student.Id,
                    RoleId = _rolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "HighSchool").RoleId

                };

                UserRoles.Add(userRole);
                student.Roles = UserRoles;
                _highScoolAppService.Create(student);
                //add action data
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

        public override ActionResult Delete(int id)
        {
            var data = _highScoolAppService.findStudent(id);
            return View(data);
        }
        public ActionResult UserProfile()
        {
            var data = _highScoolAppService.findByEmail(User.Identity.Name);
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
        public override ActionResult Edit(HighSchoolViewModel student)
        {
            var studentVievModel = _highScoolAppService.Validate(student);
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
        public override ActionResult Delete(int id, FormCollection formCollection)
        {
            ActionData data = SetActionData();
            data.Id = id;
              _actionDataService.Create(data);
            return base.Delete(id, formCollection);
        }

        public bool CheckError(HighSchoolViewModel highSchool)
        {
            if (highSchool.Er_Name == null && highSchool.Er_LastName == null && highSchool.Er_Email == null && highSchool.Er_Password == null && highSchool.Er_PhoneNumber == null && highSchool.Er_Address == null)
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

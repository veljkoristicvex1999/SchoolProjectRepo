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
        private IHighScoolAppService _highScoolAppService;
        private IRolesService _rolesService;
        private IMapper mapper;
        
        public HighSchoolStudentsController(IHighScoolAppService _highScoolAppService, IRolesService _rolesService, IMapper mapper) :base(_highScoolAppService)
        {
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
        public override ActionResult Create(HighSchoolStudents student)
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
            return RedirectToAction("Index");
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
    }
}

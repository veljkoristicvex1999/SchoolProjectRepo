using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessObjectModel;

namespace LayeredSolution.Controllers
{
    public class HighSchoolStudentsController : GenericController<HighSchoolStudents>
    {
        private IHighSchoolService IHighSchoolService;
        private IRolesService IRolesService;

        
        public HighSchoolStudentsController(IHighSchoolService IHighSchoolService, IRolesService IRolesService) :base(IHighSchoolService)
        {
            this.IHighSchoolService = IHighSchoolService;
            this.IRolesService = IRolesService;
        }

        [Authorize(Roles ="Admin,Professor")]
        public ActionResult Export(int id)
        {
            var model = IHighSchoolService.findStudent(id);
            if (model != null)
            {
                IHighSchoolService.Export(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("NotFound");
        }

        [Authorize(Roles = "Admin,Professor")]
        public ActionResult Search(String Search)
        {
            var model = IHighSchoolService.Search(Search.Trim());
            return View(model);
        }

        [Authorize(Roles = "Admin,Professor")]
        public override ActionResult Edit(int id)
        {

            ViewBag.isReadOnly = false;
            var model = IHighSchoolService.findStudent(id);
            if (model != null)
            {
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Professor")]
        public override ActionResult Details(int id)
        {
            ViewBag.isReadOnly = true;
            var model = IHighSchoolService.findStudent(id);
            return View("Edit", model);
        }
    
        [Authorize(Roles = "HighSchool,Professor,Admin")]
        public override ActionResult Index()
        {

            var model = IHighSchoolService.GetAllStudents();
            return View(model);
        }
        [Authorize(Roles = "Admin,Professor")]
        public override ActionResult Create(HighSchoolStudents student)
        {
            List<UserRoles> UserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = student.Id,
                RoleId = IRolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "HighSchool").RoleId

            };

            UserRoles.Add(userRole);
            student.Roles = UserRoles;
            IHighSchoolService.Create(student);
            return RedirectToAction("Index");
            //ovde zeza
        }
    }
}

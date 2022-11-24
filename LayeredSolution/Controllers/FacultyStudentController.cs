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
    public class FacultyStudentController : GenericController<FaculltyStudents>

    {
        private IRolesService IRolesService;
        private IFacultyStudentService IFacultyStudentService;

        public FacultyStudentController(IFacultyStudentService IFacultyStudentService, IRolesService IRolesService) : base(IFacultyStudentService)
        {
            this.IRolesService = IRolesService;
            this.IFacultyStudentService = IFacultyStudentService;
        }
        [Authorize(Roles = "Professor,Admin")]
        public ActionResult Search(String Search)
        {
           var model = IFacultyStudentService.Search(Search.Trim());
            return View(model);
        }

        [Authorize(Roles = "Professor,Admin")]
        public ActionResult Export(int id)
        {
            var model = IFacultyStudentService.findStudent(id);
            if(model != null)
            {
                IFacultyStudentService.Export(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("NotFound");
        }

        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult  Edit(int id)
        {

            ViewBag.isReadOnly = false;
            ViewBag.ShowButton = null;
            var model = IFacultyStudentService.findStudent(id);
            if (model != null)
            {
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Details(int id)
        {
            ViewBag.isReadOnly = true;
            ViewBag.ShowButton = "disabled";
            var model = IFacultyStudentService.findStudent(id);
            return View("Edit", model);
        }

        [Authorize(Roles = "Facullty,Professor,Admin")]

        public override ActionResult Index()
        {

            var model = IFacultyStudentService.GetAllStudents();
            return View(model);
        }

        [Authorize(Roles = "Professor,Admin")]
        public override ActionResult Create(FaculltyStudents student)
        {
            List<UserRoles> UserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = student.Id,
                RoleId = IRolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "Facullty").RoleId

            };
            UserRoles.Add(userRole);
            student.Roles = UserRoles;
            IFacultyStudentService.Create(student);
            return RedirectToAction("Index");
        }

      

    }
}
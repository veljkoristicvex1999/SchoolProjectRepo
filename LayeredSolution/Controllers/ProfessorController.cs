using BusinessLayer;
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
    public class ProfessorController : GenericController<Professor>
    {
        private IRolesService IRolesService;
       private IProfessorService IProfessorService;

       public ProfessorController(IProfessorService IProfessorService, IRolesService IRolesService) : base(IProfessorService)
        {
            this.IRolesService = IRolesService;
            this.IProfessorService = IProfessorService;
        }
        [Authorize(Roles = "Professor, Admin")]
        public override ActionResult Index()
        {

            var model = IProfessorService.GetAllStudents();
            return View(model);
        }
         [Authorize(Roles = "Admin")]
        public override ActionResult Create(Professor student)
        {
            List<UserRoles> UserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = student.Id,
                RoleId = IRolesService.getAllRoles().FirstOrDefault(r => r.RoleName == "Professor").RoleId

            };
            UserRoles.Add(userRole);
            student.Roles = UserRoles;
            IProfessorService.Create(student);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Search(String Search)
        {
            var model = IProfessorService.Search(Search.Trim());
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public override ActionResult Edit(int id)
        {

            ViewBag.isReadOnly = false;
            ViewBag.ShowButton = null;
            var model = IProfessorService.findStudent(id);
            if (model != null)
            {
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public override ActionResult Details(int id)
        {
            ViewBag.isReadOnly = true;
            ViewBag.ShowButton = "disabled";
            var model = IProfessorService.findStudent(id);
            return View("Edit", model);
        }




    }
}

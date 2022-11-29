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
        private IRolesService IRolesService;
        private IFaculltyAppService faculltyAppService;
        private IMapper mapper;
        public FacultyStudentController(IFaculltyAppService faculltyAppService, IRolesService IRolesService,  IMapper mapper) : base(faculltyAppService)
        {
            this.mapper = mapper;
            this.IRolesService = IRolesService;
            this.faculltyAppService = faculltyAppService;
        }


        [Authorize(Roles = "Professor,Admin")]
        public ActionResult Search(String Search)
        {
           var model = faculltyAppService.Search(Search.Trim());
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
        public override ActionResult  Edit(int id)
        {          
            var data = faculltyAppService.findStudent(id);
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
            var data = faculltyAppService.findStudent(id);
            data.isReadOnly = true;
            data.ShowButton = "disabled";
            return View("Edit", data);
        }


        [Authorize(Roles = "Facullty,Professor,Admin")]
        public override ActionResult Index()
        {

            var data = faculltyAppService.GetAllStudents();       
            return View(data);
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
            faculltyAppService.Create(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public override ActionResult Delete(int id)
        {
            var data = faculltyAppService.findStudent(id);          
            return View(data);
        }
 
    }
}
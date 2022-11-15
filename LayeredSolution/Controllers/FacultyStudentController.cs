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
        private IFacultyStudentService IFacultyStudentService;

        public FacultyStudentController(IFacultyStudentService IFacultyStudentService) : base(IFacultyStudentService)
        {
            this.IFacultyStudentService = IFacultyStudentService;
        }

       public ActionResult Search(String Search)
        {
           var model = IFacultyStudentService.Search(Search.Trim());
            return View(model);
        }
     
        
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
        public override ActionResult Details(int id)
        {
            ViewBag.isReadOnly = true;
            ViewBag.ShowButton = "disabled";
            var model = IFacultyStudentService.findStudent(id);
            return View("Edit", model);
        }

    }
}
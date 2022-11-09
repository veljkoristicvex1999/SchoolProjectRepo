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
    }
}
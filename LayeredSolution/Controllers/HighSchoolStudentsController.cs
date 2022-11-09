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

        
        public HighSchoolStudentsController(IHighSchoolService IHighSchoolService) :base(IHighSchoolService)
        {
            this.IHighSchoolService = IHighSchoolService;
        }


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
        public ActionResult Search(String Search)
        {
            var model = IHighSchoolService.Search(Search.Trim());
            return View(model);
        }
    }
}

using BusinessLayer;
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
    public class AdminController : GenericController<Admin>
    {
        private IAdminService IAdminService;

        public AdminController(IAdminService IAdminService) : base(IAdminService)
        {
            this.IAdminService = IAdminService;
        }

        [Authorize(Roles = "Admin")]
        public override ActionResult Index()
        {

            var model = IAdminService.GetAllStudents();
            return View(model);
        }
    }
}
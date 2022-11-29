using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
    public class AdminController : GenericController<Admin, AdminViewModel>
    {
        private IAdminAppService _adminAppService;       
       
        public AdminController(IAdminAppService _adminAppService, IMapper mapper) : base(_adminAppService)
        {
            this._adminAppService = _adminAppService;
        }
        [Authorize(Roles = "HighSchool,Professor,Admin")]
        public override ActionResult Index()
        {
            var model = _adminAppService.GetAllStudents();
            return View(model);
        }

    }
}
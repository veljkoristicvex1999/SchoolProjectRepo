using AutoMapper;
using BusinessObjectModel;
using LayeredSolution.ViewModels;
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
            return View();
        }
        public ActionResult UserProfile()
        {
            var data = _adminAppService.findByEmail(User.Identity.Name);
            return View(data);
        }

    }
}
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		// only registered user will access this method
		//public ActionResult UserArea()
  //      {
		//	return View();
  //      }
		//public ActionResult AdminArea()
  //      {
		//	return View();
  //      }
	}
}
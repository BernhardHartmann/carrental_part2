using System.Web.Mvc;
using CarManagement.App_Start;

namespace CarManagement.Controllers
{
	public class HomeController : Controller
	{
		public CarManagementContext Context = new CarManagementContext();

		public ActionResult Index()
		{
			Context.Database.GetStats();
			return Json(true, JsonRequestBehavior.AllowGet);
		}	
	}
}
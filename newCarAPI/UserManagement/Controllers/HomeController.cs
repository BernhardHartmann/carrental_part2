using System.Web.Mvc;
using UserManagement.App_Start;

namespace UserManagement.Controllers
{
	public class HomeController : Controller
	{
		public UserManagementContext Context = new UserManagementContext();

		public ActionResult Index()
		{
			Context.Database.GetStats();
			return Json(Context.Database.Server.BuildInfo, JsonRequestBehavior.AllowGet);
		}	
	}
}
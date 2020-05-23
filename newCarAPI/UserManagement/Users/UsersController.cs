namespace UserManagement.Users
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using App_Start;
	using MongoDB.Bson;
	using MongoDB.Driver.Builders;
	using MongoDB.Driver.GridFS;
	using MongoDB.Driver.Linq;

	public class UsersController : Controller
	{
		public readonly UserManagementContext Context = new UserManagementContext();

		public ActionResult Index(UsersFilter filters)
		{
			var users = FilterUsers(filters);
			var model = new UsersList
			{
				Users = users,
				Filters = filters
			};
			return Json(users, JsonRequestBehavior.AllowGet);
			//return View(model);
		}

		private IEnumerable<User> FilterUsers(UsersFilter filters)
		{
			IQueryable<User> users = Context.Users.AsQueryable()
				.OrderBy(r => r.Email);

			if (filters.Email != null && filters.Password != null)
			{
				users = users
					.Where(r => r.Email == filters.Email && r.Password == filters.Password);
			}

			//if (filters.Password != "")
			//{
			//	var query = Query<User>.LTE(r => r.Price, filters.PriceLimit);
			//	users = users
			//		.Where(r => query.Inject());
			//}

			return users;
		}

		public ActionResult Post()
		{
			return Json(true, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult Post(User postUser)
		{
			var user = new User(postUser);
			Context.Users.Insert(user);
			return Json(true, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EditUser(User editUser)
		{
			var user = new User(editUser);
			Context.Users.Save(user);
			return Json(true, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult EditUser(string id, User editUser)
		{
			var user = GetUser(id);

			return Json(user, JsonRequestBehavior.AllowGet);
		}
			
		private User GetUser(string id)
		{
			var user = Context.Users.FindOneById(new ObjectId(id));
			return user;
		}

		public ActionResult Delete(string id)
		{
			Context.Users.Remove(Query.EQ("_id", new ObjectId(id)));
			return Json(true, JsonRequestBehavior.AllowGet);
			//return RedirectToAction("Index");
		}		
	}
}
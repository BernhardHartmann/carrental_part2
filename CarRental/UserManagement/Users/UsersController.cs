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
			return View(model);
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
			return View();
		}

		[HttpPost]
		public ActionResult Post(PostUser postUser)
		{
			var user = new User(postUser);
			Context.Users.Insert(user);
			return RedirectToAction("Index");
		}

		public ActionResult EditUser()
		{
			return View();
		}

		[HttpPost]
		public ActionResult EditUser(string id, EditUser editUser)
		{
			var user = GetUser(id);
			//user.AdjustPrice(adjustPrice);
			//Context.Users.Save(user);
			//Context.Users.Save(user);
			return View(user);
			//return RedirectToAction("Index");
		}
			
		private User GetUser(string id)
		{
			var user = Context.Users.FindOneById(new ObjectId(id));
			return user;
		}

		public ActionResult Delete(string id)
		{
			Context.Users.Remove(Query.EQ("_id", new ObjectId(id)));
			return RedirectToAction("Index");
		}		
	}
}
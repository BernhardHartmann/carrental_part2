namespace CarManagement.Car
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
	using System.Web.Mvc;
	using App_Start;
    using CarManagement.Categories;
    using CarManagement.Locations;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
	using MongoDB.Driver.GridFS;
	using MongoDB.Driver.Linq;

	public class CarController : Controller
	{
		public readonly CarManagementContext Context = new CarManagementContext();

		public ActionResult Index(CarsFilter filters)
		{
			var cars = FilterCars(filters);
			var model = new CarsList
			{
				Cars = cars,
				Filters = filters
			};
			return View(model);
		}

		private IEnumerable<Car> FilterCars(CarsFilter filters)
		{
			IQueryable<Car> cars = Context.Cars.AsQueryable()
				.OrderBy(r => r.CarId);

			//if (filters.Email != null && filters.Password != null)
			//{
			//	cars = cars
			//		.Where(r => r.Email == filters.Email && r.Password == filters.Password);
			//}

			//if (filters.Password != "")
			//{
			//	var query = Query<User>.LTE(r => r.Price, filters.PriceLimit);
			//	cars = cars
			//		.Where(r => query.Inject());
			//}

			return cars;
		}

		public IEnumerable<Location> getInterntLocationList()
		{
			IQueryable<Location> locations = Context.Location.AsQueryable()
				.OrderBy(r => r.LocationId);

			return locations;
		}

		[HttpGet]
		public ActionResult getLocationList()
		{
			IQueryable<Location> locations = Context.Location.AsQueryable()
				.OrderBy(r => r.LocationId);

			return Json(locations.Count(), JsonRequestBehavior.AllowGet);
		}

		public IEnumerable<Category> getCategoryList()
		{
			IQueryable<Category> categories = Context.Categories.AsQueryable()
				.OrderBy(r => r.CategoryId);

			return categories;
		}

		public ActionResult Post()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Post(Car car)
		{			
			try
			{
				var locations = getInterntLocationList();
				var categories = getCategoryList();
			
				// check if Location & Category is already in DB
				if (car.Location != null  && locations.Where(x => x.LocationId == car.Location.LocationId).Count() == 1 &&   categories.Where(x => x.CategoryId == car.Category.CategoryId).Count() == 1)
				{
					Context.Cars.Insert(car);
					return Json(true);
				}
				return Json(false);
			}
			catch(Exception ex)
			{
				return Json(false);
			}
			//return new HttpResponseMessage(HttpStatusCode.OK);
			//return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult Put(Car car)
		{
			var newCar = new Car(car);
			try
			{
				Context.Cars.Insert(newCar);
				return Json(true);
			}
			catch (Exception ex)
			{
				return Json(false);
			}
		}

		[HttpPost]
		public ActionResult EditCar(string id, EditCar editUser)
		{
			var car= GetCar(id);
			return View(car);
			//return RedirectToAction("Index");
		}
		
		private ActionResult GetCar(string id)
		{
			try
			{
			var car = Context.Cars.FindOneById(new ObjectId(id));
				return Json(car);
			}
			catch (Exception ex)
			{
				return Json(false);
			}
		}

		public ActionResult GetAllCars()
		{
			IQueryable<Car> cars = Context.Cars.AsQueryable().OrderBy(r => r.CarId);
			return Json(cars, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetCarByDocumentID(string id)
		{
			try
			{
				var car = Context.Cars.FindOneById(new ObjectId(id));
				return Json(car, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(false);
			}
		}

		public ActionResult GetCarByID(int id)
		{
			try
			{
								
				var car = Context.Cars.FindOne(Query.EQ("CarId", id));
				return Json(car, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(false);
			}
		}

		public ActionResult GetCarCountByCatID(int cat_id)
		{
			try
			{
				var carCounter = Context.Cars.Find(Query.EQ("CatId", cat_id)).Count();
				return Json(carCounter, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(false);
			}
		}

		public ActionResult GetCarCountPerCat(int id)
		{
			try
			{
				var count = Context.Cars.AsQueryable().Where(s => s.Category.CategoryId == id).Count();

				return Json(count, JsonRequestBehavior.AllowGet);

				//var group = new BsonDocument
				//{
				//	{ "$group",
				//		new BsonDocument
				//			{
				//				{ "_id", new BsonDocument
				//							 {
				//								 {
				//									 "Category","$Category.CategoryId"
				//								 }
				//							 }
				//				},
				//				{
				//					"Count", new BsonDocument
				//								 {
				//									 {
				//										 "sum", 1
				//									 }
				//								 }
				//				}
				//			}
				//  }
				//};

				//var pipeline = new[] { group };
				//var result = Context.Cars.AsQueryable().GroupBy(x => x.Category.CategoryId);


				//var matchingExamples = result.ResultDocuments
				//	.Select(x => x.ToDynamic())
				//	.ToList();

				//var carListPerCategory = Context.Cars.AsQueryable().GroupBy(x => x.CarId);

				//IQueryable<Car> cars = Context.Cars.AsQueryable();

			}
			catch (Exception ex)
			{
				return Json(false);
			}
		}

		public ActionResult DeleteCar(string id)
		{
			Context.Cars.Remove(Query.EQ("_id", new ObjectId(id)));
			return RedirectToAction("Index");
		}		
	}
}
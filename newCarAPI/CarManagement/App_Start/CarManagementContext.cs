namespace CarManagement.App_Start
{
	using MongoDB.Driver;
	using CarManagement.Properties;
	using Car;
    using CarManagement.Categories;
    using CarManagement.Locations;
    using System.Collections.Generic;
    using MongoDB.Driver.Linq;
    using System.Linq;
    using MongoDB.Bson;

    public class CarManagementContext
	{
		public IMongoDatabase IDatabase;
		public MongoDatabase Database;
		MongoServer server;
		

		public CarManagementContext()
		{
			var client = new MongoClient(Settings.Default.ConnectionString);
			var server = client.GetServer();
			Database = server.GetDatabase("carManagement");
		}

		
		public MongoCollection<Car> Cars
		{
			get
			{
				return Database.GetCollection<Car>("cars");
			}
		}

		public MongoCollection<Category> Categories
		{
			get
			{				
				return Database.GetCollection<Category>("Categories");
			}
		}

		public MongoCollection<Location> Location
		{
			get
			{				
				return Database.GetCollection<Location>("Locations");
			}
		}

		public List<Location> LocationList
		{
			get
			{
				var collection = Database.GetCollection<Location>("Locations");
				return new List<Location>();
				//var test = collection.FindAll().ToList();
				//IMongoCollection<Location> test = Database.GetCollection<Location>("location").get.Find(new BsonDocument()).ToList();
				//return Database.GetCollection<Location>("Locations").Find().ToList();
				//var filter = Builders<BsonDocument>.Filter.("carud", 10000);

				//var Context = new CarManagementContext();
				//return Context.Location.AsQueryable().OrderBy(r => r.LocationId).ToList();
				
				//List<MongoCollection<Location>> tempList = new List<MongoCollection<Location>>();
				//foreach (var tempLoc in locationList)
				//{
				//	loc.Id = tempLoc.Id;
				//	loc.LocationId = tempLoc.LocationId;
				//	loc.Street = tempLoc.Street;
				//	loc.Streetno = tempLoc.Streetno;
				//	loc.City = tempLoc.City;
				//	loc.Zipcode = tempLoc.Zipcode;
				//	loc.State = tempLoc.State;
				//	loc.Country = tempLoc.Country;
				//	loc.Longitude = tempLoc.Longitude;
				//	loc.Latitude = tempLoc.Latitude;
				//	loc.Timestamp = tempLoc.Timestamp;
				//	loc.BranchName = tempLoc.BranchName;
				//	tempList.Add(loc);
				//	loc = new Location();
				//}

				//return tempList;
				
				//await SpeCollection.Find(new Location()).to
			}
		}

	}
}








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
			//var client = new MongoClient(Settings.Default.ConnectionString);
			//string con = "mongodb://test:test@Cluster0-shard-0/cluster0-shard-00-00-bj19b.azure.mongodb.net:27017";
			MongoClient client = new MongoClient("mongodb://test:test@cluster0-shard-00-00-bj19b.azure.mongodb.net:27017,cluster0-shard-00-01-bj19b.azure.mongodb.net:27017,cluster0-shard-00-02-bj19b.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
			var database = client.GetDatabase("carManagement");
			var server = client.GetServer();
			Database = server.GetDatabase("carManagement");

			//MongoClient client1 = new MongoClient("mongodb://uc3neklrclokxhfeb1ra:mpKDX4ecVxJchT2qTH6E@ba6nrxnx4ynf068-mongodb.services.clever-cloud.com:27017/ba6nrxnx4ynf068");
			//var server = client1.GetServer(); 
			//Database = server.GetDatabase("ba6nrxnx4ynf068");

			var test = this.Cars.AsQueryable().Count();
			//var client1 = new MongoClient(con);
			//var client2 = new MongoClient("mongodb://uc3neklrclokxhfeb1ra:mpKDX4ecVxJchT2qTH6E@ba6nrxnx4ynf068-mongodb.services.clever-cloud.com:27017/ba6nrxnx4ynf068");
			//var client3 = new MongoClient("mongodb" +"+" +"srv://test:test@cluster0-bj19b.azure.mongodb.net/test");
			//var server3 = client.GetServer(); 
			//var database3 = server3.GetDatabase("test");

			//server = client.GetServer();
			//Database = server.GetDatabase("userManagement");
			//Database = server.GetDatabase(Settings.Default.DatabaseName);
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








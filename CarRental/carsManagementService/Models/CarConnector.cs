using carsManagementService.Properties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace carsManagementService.Models
{
    public class CarConnector
    {
        private MongoDatabase _database;
        protected Carsrepository<Car> _cars;
        public CarConnector()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoDBConectionString"]);
            var server = client.GetServer();
            _database = server.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabaseName"]);
            var collection = _database.GetCollection<Car>("Cars");
        }
        public Carsrepository<Car> Cars
        {
            get
            {
                if (_cars == null) _cars = new Carsrepository<Car>(_database, "cars");
                return _cars;
            }
        }
    }
}
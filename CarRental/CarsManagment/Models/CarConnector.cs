using CarsManagment.Properties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarsManagment.Models
{
    public class CarConnector
    {
        private MongoDatabase _database;
        protected Carsrepository<Cars> _cars;
        public CarConnector()
        {
            var client = new MongoClient(Settings.Default.ConnectionString);
            var server = client.GetServer();
            _database = server.GetDatabase(Settings.Default.DatabaseName);
            var collection = _database.GetCollection<Cars>("Cars");
        }
        public Carsrepository<Cars> Cars
        {
            get
            {
                if (_cars == null) _cars = new Carsrepository<Cars>(_database, "cars");
                return _cars;
            }
        }
    }
}
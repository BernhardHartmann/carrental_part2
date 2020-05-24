using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement
{
    public class CarDBConnector
    {
        public IConfiguration Configuration { get; private set; }
        public MongoDatabase Database;
        public CarDBConnector()
        {
            //MongoClient client = new MongoClient("mongodb://localhost");
            //var server = client.GetServer();
            //Database = server.GetDatabase("CustomerManagement");
           
            string con = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Mongo")["DB_ConnectionString"];
            var client = new MongoClient(con);
            var server = client.GetServer();
            //replace server with client if not worked
            Database = server.GetDatabase(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Mongo")["DB_Name"]);
        }

        public MongoCollection<Car> Cars => Database.GetCollection<Car>("Cars");

        public MongoCollection<Category> Categories
        {
            get
            {
                return Database.GetCollection<Category>("Categories");
            }
        }

        public MongoCollection<Location> Locations => Database.GetCollection<Location>("Locations");       
    }
}

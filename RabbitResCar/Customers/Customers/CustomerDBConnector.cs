using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers
{
    public class CustomerDBConnector
    {
        public MongoDatabase Database;
        public  CustomerDBConnector()
        {
            //MongoClient client = new MongoClient("mongodb://localhost");
            //var server = client.GetServer();
            //Database = server.GetDatabase("xxx");
            //var client = new MongoClient("xxx");
            //var server = client.GetServer(); 
            //Database = server.GetDatabase("xxx");

            string con = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Mongo")["DB_ConnectionString"];
            var client = new MongoClient(con);
            var server = client.GetServer();
            //replace server with client if not worked
            Database = server.GetDatabase(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Mongo")["DB_Name"]);

        }

        public MongoCollection<Customer> Customers
        {
            get
            {
                return Database.GetCollection<Customer>("Customers");
            }
        }
    }
}

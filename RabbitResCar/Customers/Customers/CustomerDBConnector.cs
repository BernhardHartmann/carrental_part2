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
            //Database = server.GetDatabase("CustomerManagement");
            var client = new MongoClient("mongodb://test:test@cluster0-shard-00-00-bj19b.azure.mongodb.net:27017,cluster0-shard-00-01-bj19b.azure.mongodb.net:27017,cluster0-shard-00-02-bj19b.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
            var server = client.GetServer(); 
            Database = server.GetDatabase("CustomerManagement");
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

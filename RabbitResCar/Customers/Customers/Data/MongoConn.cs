using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Data
{
    class MongoConn
    {
        private const string mongoConnString = "xxxx";
        private MongoClient client;

        public MongoConn()
        {
            client = new MongoClient(mongoConnString);
        }

        public IMongoCollection<BsonDocument> getCollection(string databaseName, string collName)
        {
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<BsonDocument>(collName);
        }

    }
}

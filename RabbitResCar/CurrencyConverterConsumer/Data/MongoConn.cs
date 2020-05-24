using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsumer.Data
{
    class MongoConn
    {
        private const string mongoConnString = "mongodb://test:test@cluster0-shard-00-00-bj19b.azure.mongodb.net:27017,cluster0-shard-00-01-bj19b.azure.mongodb.net:27017,cluster0-shard-00-02-bj19b.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ReservationConsumer
{
    public class ReservationReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        public ReservationReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)

        {
            Console.WriteLine($"Consuming Message");
            Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body)));

            Reservation reservationConsumed = JsonConvert.DeserializeObject<Reservation>(Encoding.UTF8.GetString(body));
            Console.WriteLine(string.Concat("desirialized: ", reservationConsumed.CarID));
            Console.WriteLine(string.Concat("Message: ", reservationConsumed.CategoryID));

            //MongoConn
            var client = new MongoClient("mongodb://test:test@cluster0-shard-00-00-bj19b.azure.mongodb.net:27017,cluster0-shard-00-01-bj19b.azure.mongodb.net:27017,cluster0-shard-00-02-bj19b.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");  
            var db = client.GetDatabase("ReservationManagement");

            //var client = new MongoClient();
            //var db = client.GetDatabase("ReservationMgmt");
            var coll = db.GetCollection<BsonDocument>("Reservation");

            //ReservationInsert
            var insert = new BsonDocument
            {
                {"CarID", reservationConsumed.CarID },
                {"CategoryID", reservationConsumed.CategoryID },
                {"LocationID", reservationConsumed.LocationID },
                {"CurrencyID", reservationConsumed.CurrencyID },
                {"StartDate", reservationConsumed.StartDate },
                {"EndDate", reservationConsumed.EndDate },
               
            };

            coll.InsertOneAsync(insert);

            Console.WriteLine("inserted");

            _channel.BasicAck(deliveryTag, false);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

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

            if (exchange.Equals("request.reservation"))
            {
                //MongoConn
                var client = new MongoClient("mongodb://test:test@cluster0-shard-00-00-bj19b.azure.mongodb.net:27017,cluster0-shard-00-01-bj19b.azure.mongodb.net:27017,cluster0-shard-00-02-bj19b.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
                var db = client.GetDatabase("ReservationManagement");
                var coll = db.GetCollection<BsonDocument>("Reservation");

                if (routingKey.Equals("get_res_by_id_key"))
                {

                    Console.WriteLine("get ReservationID " + Encoding.UTF8.GetString(body));

                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(Encoding.UTF8.GetString(body)));
                    var reservationSearched = coll.Find(filter).FirstOrDefault();

                    var myReservation = BsonSerializer.Deserialize<Reservation>(reservationSearched);

                    Console.WriteLine("myReservation LocID " + myReservation.LocationID);
                   // Console.WriteLine("myReservation CurrencyID" + myReservation.CurrencyExchangeRate);
                    Console.WriteLine("myReservation StartDate " + myReservation.StartDate);
                    Console.WriteLine("myReservation EndDate " + myReservation.EndDate);
                    Console.WriteLine("myReservation categoryID " + myReservation.CurrencyExchangeRate);

                    //TODO send GW
                 
                }
                else
                {
                    if (routingKey.Equals("reservation_key"))
                    {
                        Reservation reservationConsumed = JsonConvert.DeserializeObject<Reservation>(Encoding.UTF8.GetString(body));

                        //ReservationInsert
                        var insert = new BsonDocument
                        {
                            {"CarID", reservationConsumed.CarID },
                            {"CategoryID", reservationConsumed.CurrencyExchangeRate },
                            {"LocationID", reservationConsumed.LocationID },

                            // TODO get CurrencyExchangeRate from PALOS Microservice


                            

                            {"CurrencyID", reservationConsumed.CurrencyExchangeRate },
                            {"StartDate", reservationConsumed.StartDate },
                            {"EndDate", reservationConsumed.EndDate }

                        };

                        coll.InsertOneAsync(insert);
                        Console.WriteLine("inserted");
                    }
                }
                _channel.BasicAck(deliveryTag, false);
            }
        }
    }
}

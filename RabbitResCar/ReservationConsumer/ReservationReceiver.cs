﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using ReservationConsumer.Data;
using CurrencyConverterClient;
using MongoDB.Driver.Builders;

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
            var client = new MongoClient("mongodb://test:test@cluster0-shard-00-00-bj19b.azure.mongodb.net:27017,cluster0-shard-00-01-bj19b.azure.mongodb.net:27017,cluster0-shard-00-02-bj19b.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
            var db = client.GetDatabase("ReservationManagement");
            var coll = db.GetCollection<BsonDocument>("Reservation");

            Console.WriteLine($"Consuming Message");
            Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body)));          


            if (exchange.Equals("request.reservation"))
            {
                //MongoConn
                

                if (routingKey.Equals("reservation.get.by.id"))
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
                    if (routingKey.Equals("reservation.create"))
                    {
                        Reservation reservationConsumed = JsonConvert.DeserializeObject<Reservation>(Encoding.UTF8.GetString(body));

                        //EXAMPLE exchange request
                        //step 1 - create request
                        RpcRequest request = new RpcRequest { fromCCY = "USD", toCCY = "EUR" };
                        //step 2 - send request 
                        RpcResponse testResponse = Task.Run(async () => await RpcCurrencyConverter.GetRpcResult(request)).Result;
                        //step 3 - read response
                        double exchangeRate = testResponse.exchangeRate;

                        //ReservationInsert
                        var insert = new BsonDocument
                        {
                            {"CarID", reservationConsumed.CarID },
                            {"CategoryID", reservationConsumed.CategoryID },
                            {"LocationID", reservationConsumed.LocationID },
                            {"CustomerID", reservationConsumed.CustomerID },
                            // TODO get CurrencyExchangeRate from PALOS Microservice
                            {"Price" ,  reservationConsumed.Price * exchangeRate},
                            { "CurrencyID", reservationConsumed.CurrencyID },
                            {"CurrencyExchangeRate", reservationConsumed.CurrencyExchangeRate },
                            {"StartDate", reservationConsumed.StartDate },
                            {"EndDate", reservationConsumed.EndDate }

                        };

                        coll.InsertOneAsync(insert);

                        DirectMessageToGateway ds = new DirectMessageToGateway();
                        ds.SendMessage(insert.ToString());
                        Console.WriteLine("inserted");
                    }
                    else if (routingKey.Equals("reservation.delete"))
                    {
                        string reservationId = JsonConvert.DeserializeObject<string>(Encoding.UTF8.GetString(body));
                        
                        coll.DeleteOneAsync(reservationId);

                        DirectMessageToGateway ds = new DirectMessageToGateway();
                        ds.SendMessage("true");
                        Console.WriteLine("deleted");
                    }
                }
            }
        }
      
    }
}

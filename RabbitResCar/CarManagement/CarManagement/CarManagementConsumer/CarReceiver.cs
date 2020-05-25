﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Threading;
using CarManagement.Data;

namespace CarManagement
{
    public class CarReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private CarService carservice;
        private ConnectionClass connClass;
        private static QueueingBasicConsumer _consumer;
        public CarReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            RabbitDataHandler rabbitDataHandler = new RabbitDataHandler();
            CarService carService = new CarService();
            string result = "";
            string documentID = "";
            try
            {
                if (exchange.Equals("request.cars"))
                {
                    connClass = new ConnectionClass();
                    ConnectionFactory connectionFactory = connClass.getConnectionFactored();
                    var model = connClass.getModel();
                    connClass.getProperties().Persistent = false;
                    switch (routingKey)
                    {
                        // update is Available
                        case "request.reservecar":
                            documentID = JsonConvert.DeserializeObject<string>(Encoding.UTF8.GetString(body));
                            result= carService.markCarAsReserved(documentID);
                            break;

                        // get available Cars Count By Category & Location
                        case "request.get.car.counter":
                            var getcarcounter_locationAndCat = JsonConvert.DeserializeObject<Object>(Encoding.UTF8.GetString(body));
                            var getcarcounter_Location = ((Newtonsoft.Json.Linq.JContainer)getcarcounter_locationAndCat).First;
                            var getcarcounter_LocationID = ((Newtonsoft.Json.Linq.JProperty)getcarcounter_Location).Value;
                            var getcarcounter_category = ((Newtonsoft.Json.Linq.JContainer)getcarcounter_locationAndCat).Last;
                            var getcarcounter_categoryID = ((Newtonsoft.Json.Linq.JProperty)getcarcounter_Location).Value;

                            result = carService.get_CarCount_CategoryCount_PerLocation((int)getcarcounter_LocationID, (int)getcarcounter_categoryID);
                            break;
                        // Get random car
                        case "request.get.random.car":
                            var locationAndCat = JsonConvert.DeserializeObject<Object>(Encoding.UTF8.GetString(body));
                            var Location = ((Newtonsoft.Json.Linq.JContainer)locationAndCat).First;
                            var LocationID = ((Newtonsoft.Json.Linq.JProperty)Location).Value;
                            var category = ((Newtonsoft.Json.Linq.JContainer)locationAndCat).Last;
                            var categoryID = ((Newtonsoft.Json.Linq.JProperty)Location).Value;

                            result = carService.get_RandomCarBy_Category_And_Location((int)LocationID, (int)categoryID);
                            break;                            

                        case "request.car.delete":
                            documentID = JsonConvert.DeserializeObject<string>(Encoding.UTF8.GetString(body));
                            result =  carService.DeleteCarByDocumentID(documentID);
                            break;
                        case "request.get.categories.by.locationid":
                            int LocID = JsonConvert.DeserializeObject<int>(Encoding.UTF8.GetString(body));
                            result = carService.getCategoriesListPerLocation(LocID);
                            break;

                        case "request.get.locationlist":                           
                            result = carService.getLocationList();
                            break;

                    }
                    byte[] messagebuffer = Encoding.Default.GetBytes(result);
                    model.BasicPublish(exchange, routingKey, connClass.getProperties(), messagebuffer);
                    
                    //var ea = _consumer.Queue.Dequeue();
                    //var props = ea.BasicProperties;
                    //var replyProps = _channel.CreateBasicProperties();
                    //replyProps.CorrelationId = props.CorrelationId;

                    //long deliveryTag = envelope.getDeliveryTag();
                    _channel.BasicAck(deliveryTag, true);
                }
                
            }
            catch(Exception ex)
            {

            }
           

            Console.WriteLine($"Consuming Message");
            //Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            //Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            //Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            //Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            //Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body)));


            //if (exchange.Equals("request.cars"))
            //{
            //    if (routingKey.Equals("get_random_car"))
            //    {

            //var locationAndCat = JsonConvert.DeserializeObject<Object>(Encoding.UTF8.GetString(body));
            //var Location = ((Newtonsoft.Json.Linq.JContainer)locationAndCat).First;
            //var LocationID = ((Newtonsoft.Json.Linq.JProperty)Location).Value;
            //var category = ((Newtonsoft.Json.Linq.JContainer)locationAndCat).Last;
            //var categoryID = ((Newtonsoft.Json.Linq.JProperty)Location).Value;

            //        carservice = new CarService();

            //        string randomCarJSON = carservice.get_CarBy_Category_And_Location((int)LocationID, (int)categoryID);


            //        Console.WriteLine(string.Concat("desirialized: ", locationAndCat));

            //        System.Threading.Thread.Sleep(3000);

            //        /*
            //         * DB get 
            //         */

            //        /* DirectMessageBackToCarReq ds = new DirectMessageBackToCarReq();
            //         ds.SendMessageToReservation(carConsumed);  */
            //    }
            //    Console.WriteLine("retrieved car DATA: " + body);
            //    _channel.BasicAck(deliveryTag, false);

            //}
        }
    }
}

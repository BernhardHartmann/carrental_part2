using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Threading;

namespace CarManagement
{
    public class CarReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private CarService carservice;

        public CarReceiver(IModel channel)
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


            if (exchange.Equals("request.cars"))
            {
                if (routingKey.Equals("get_random_car"))
                {

                    var locationAndCat = JsonConvert.DeserializeObject<Object>(Encoding.UTF8.GetString(body));
                    var Location = ((Newtonsoft.Json.Linq.JContainer)locationAndCat).First;
                    var LocationID = ((Newtonsoft.Json.Linq.JProperty)Location).Value;
                    var category = ((Newtonsoft.Json.Linq.JContainer)locationAndCat).Last;
                    var categoryID = ((Newtonsoft.Json.Linq.JProperty)Location).Value; 

                    carservice = new CarService();

                    string randomCarJSON = carservice.get_CarBy_Category_And_Location((int)LocationID, (int)categoryID);


                    Console.WriteLine(string.Concat("desirialized: ", locationAndCat));

                    System.Threading.Thread.Sleep(3000);

                    /*
                     * DB get 
                     */

                    /* DirectMessageBackToCarReq ds = new DirectMessageBackToCarReq();
                     ds.SendMessageToReservation(carConsumed);  */
                }
                Console.WriteLine("retrieved car DATA: " + body);
                _channel.BasicAck(deliveryTag, false);

            }
        }
    }
}

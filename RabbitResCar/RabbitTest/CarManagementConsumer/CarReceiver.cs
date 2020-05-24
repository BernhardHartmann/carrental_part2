using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using ReservationRequest.Data;
using ReservationRequest;
using System.Threading;
using RabbitTest;

namespace CarmanagementConsumer
{
    public class CarReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;

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


            if (exchange.Equals("request.reservation"))
            {
                if (routingKey.Equals("reservation.create"))
                {
                    var message = JsonConvert.DeserializeObject<ReservationCreate>(Encoding.UTF8.GetString(body));
                    //Console.WriteLine(string.Concat("desirialized: ", carConsumed.CarId));

                    System.Threading.Thread.Sleep(3000);

                    DirectMessageToReservation ds = new DirectMessageToReservation();
                    ds.SendMessageToReservation(message);
                }
            }

            if (exchange.Equals("request.reservation"))
            {
                if (routingKey.Equals("get_res_by_id_key"))
                {
                    Console.WriteLine("get ReservationID " + Encoding.UTF8.GetString(body));
                    DirectMessageToReservation ds = new DirectMessageToReservation();
                    ds.SendReservationByID(Encoding.UTF8.GetString(body));
                }
            }

            Console.WriteLine("retrieved car DATA: "+body);

            _channel.BasicAck(deliveryTag, false);

        }


    }
}

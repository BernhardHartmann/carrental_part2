using CarmanagementConsumer;
using RabbitMQ.Client;
using ReservationRequest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationRequest
{
    class Program
    {
        private static ConnectionClass connClass;

        static void Main(string[] args)
        {
            connClass = new ConnectionClass();
            var connectionFactory = connClass.getConnectionFactored();

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.BasicQos(0, 1, false);
            CarReceiver messageReceiver = new CarReceiver(channel);
            channel.BasicConsume("cars.queue", false, messageReceiver);
            channel.BasicConsume("reservation.queue", false, messageReceiver);
            Console.ReadLine();
        }
    }
}

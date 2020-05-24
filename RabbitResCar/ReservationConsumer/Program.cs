using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationConsumer
{
    class Program
    {
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string HostName = "localhost";

        static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password,
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            // uint prefetchSize, ushort prefetchCount, bool global
            channel.BasicQos(0, 1, false);
            ReservationReceiver messageReceiver = new ReservationReceiver(channel);
            channel.BasicConsume("reservation.queue", false, messageReceiver);
            Console.ReadLine();
        }
    }
}

using RabbitMQ.Client;
using ReservationConsumer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationConsumer
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
            ReservationReceiver messageReceiver = new ReservationReceiver(channel);
            channel.BasicConsume("reservation.queue", false, messageReceiver);
            channel.BasicConsume("request.reservation.getByID", false, messageReceiver);
            Console.ReadLine();
        }
    }
}

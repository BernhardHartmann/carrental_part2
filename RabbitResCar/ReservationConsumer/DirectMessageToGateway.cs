using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using ReservationConsumer.Data;

namespace ReservationConsumer
{
    public class DirectMessageToGateway
    {
        private string jsonString;
        private ConnectionClass connClass;


        public void SendMessage(string reservation)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            var queue = connClass.createQueue("reservation.queue");

            jsonString = JsonConvert.SerializeObject(reservation);
            byte[] messagebuffer = Encoding.Default.GetBytes(jsonString);

            model.BasicPublish("request.reservation", "reservation.receive", properties, messagebuffer);

            Console.WriteLine("Reservation Message Sent");
        }
    }

}
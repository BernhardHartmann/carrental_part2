using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using ReservationRequest.Data;
using CarmanagementConsumer;
using RabbitTest;

namespace ReservationRequest
{
    public class DirectMessageToReservation
    {
        private string jsonString;
        private ConnectionClass connClass;
      
        public void SendMessageToReservation(ReservationCreate encodedCar)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            var queue = connClass.createQueue("reservation.queue");

            Reservation reservation = new Reservation();
            reservation.CategoryID = encodedCar.CategoryID;
            reservation.CarID = encodedCar.CarID;
            reservation.LocationID = encodedCar.LocationID;
            reservation.CurrencyID = 5;
            reservation.CurrencyExchangeRate = "0.8";
            reservation.StartDate = new DateTime();
            reservation.EndDate = new DateTime();

            jsonString = JsonConvert.SerializeObject(reservation);
            byte[] messagebuffer = Encoding.Default.GetBytes(jsonString);

            model.BasicPublish("request.reservation", "reservation.create", properties, messagebuffer);
            Console.WriteLine("Reservation Message Sent");

        }
        public void SendReservationByID(string id)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            var queue = connClass.createQueue("reservation.queue");

            byte[] messagebuffer = Encoding.Default.GetBytes(id);

            model.BasicPublish("request.reservation", "reservation.get.by.id", properties, messagebuffer);
            Console.WriteLine("Reservation Message - get Res By ID sent");
        }

    }

}
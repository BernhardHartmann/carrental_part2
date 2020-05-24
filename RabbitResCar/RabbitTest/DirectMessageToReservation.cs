using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using ReservationRequest.Data;
using CarmanagementConsumer;

namespace ReservationRequest
{
    public class DirectMessageToReservation
    {
        private string jsonString;
        private ConnectionClass connClass;
      
        public void SendMessageToReservation(Car encodedCar)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            Reservation reservation = new Reservation();
            reservation.CategoryID = encodedCar.CategoryId;
            reservation.CarID = encodedCar.CarId;
            reservation.LocationID = encodedCar.LocationId;
            reservation.CurrencyID = 2;
            reservation.StartDate = new DateTime();
            reservation.EndDate = new DateTime();


            jsonString = JsonConvert.SerializeObject(reservation);
            byte[] messagebuffer = Encoding.Default.GetBytes(jsonString);


            model.BasicPublish("request.reservation", "reservation_key", properties, messagebuffer);
            Console.WriteLine("Reservation Message Sent");

        }

    }

}
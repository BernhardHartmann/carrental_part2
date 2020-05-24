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
            reservation.CurrencyExchangeRate = "0.8";
            reservation.StartDate = new DateTime();
            reservation.EndDate = new DateTime();

            jsonString = JsonConvert.SerializeObject(reservation);
            byte[] messagebuffer = Encoding.Default.GetBytes(jsonString);

            model.BasicPublish("request.reservation", "reservation_key", properties, messagebuffer);
            Console.WriteLine("Reservation Message Sent");

        }
        public void SendReservationByID(string id)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            byte[] messagebuffer = Encoding.Default.GetBytes(id);

            model.BasicPublish("request.reservation", "get_res_by_id_key", properties, messagebuffer);
            Console.WriteLine("Reservation Message - get Res By ID sent");
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using CarsRequest.Data;
using System.Configuration;
using CarRequest;

namespace CarsRequest
{
    /*
     * The cars consumer is in the reservationRequest project
     */
    public class DirectMessageToCars
    {
        private string jsonStringCar;
        private string jsonStringCategory;
        private string jsonString;
        private ConnectionClass connClass;
      
        public void CreateReservation(Car car, Category category)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            
           
            jsonStringCar = JsonConvert.SerializeObject(car);
            jsonStringCategory = JsonConvert.SerializeObject(category);

            byte[] messagebuffer = Encoding.Default.GetBytes(jsonStringCar+jsonStringCategory);


            model.BasicPublish("request.cars", "cars_key", properties, messagebuffer);
            Console.WriteLine("Cars Message Sent with queue request.cars and key cars_key");

        }

        public void getRandomCar(int locationID, int categoryID)
        {

            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            string jsonLocCat = "{'locationID':'" + locationID + "','categoryID':'"+categoryID+"'}";


            byte[] messagebuffer = Encoding.Default.GetBytes(jsonLocCat);


            model.BasicPublish("request.cars", "get_random_car", properties, messagebuffer);

            Console.WriteLine("send locationID and categoryID ");

        }

        public void GetReservationByID(string id)
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            byte[] messagebuffer = Encoding.Default.GetBytes(id);

            var requestReservationExchange = ConfigurationSettings.AppSettings["exchangeReservation"];
            var getReservationByIDKey = ConfigurationSettings.AppSettings["reservationByIDKey"];


            model.BasicPublish(requestReservationExchange, getReservationByIDKey, properties, messagebuffer);

            Console.WriteLine("Cars Message Sent with queue request.reservation and key reservation_key");
           

        }

    }

}
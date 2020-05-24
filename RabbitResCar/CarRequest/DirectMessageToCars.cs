using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using CarsRequest.Data;

namespace CarsRequest
{
    public class DirectMessageToCars
    {
        private string jsonString;
        private ConnectionClass connClass;
      
        public void SendMessageToCars()
        {
            connClass = new ConnectionClass();
            ConnectionFactory connectionFactory = connClass.getConnectionFactored();

            var model = connClass.getModel();
            var properties = connClass.getProperties();
            properties.Persistent = false;

            Car car = new Car();
            car.CarId = 1;
            car.CategoryId = 33;
            car.LocationId = 99;
           
            jsonString = JsonConvert.SerializeObject(car);
            byte[] messagebuffer = Encoding.Default.GetBytes(jsonString);


            model.BasicPublish("request.cars", "cars_key", properties, messagebuffer);
            Console.WriteLine("Cars Message Sent");

        }

    }

}
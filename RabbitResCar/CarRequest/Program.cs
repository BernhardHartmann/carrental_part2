using CarsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterClient;

namespace CarsRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectMessageToCars directmessages = new DirectMessageToCars();

            Car car = new Car();
            car.CarId = 1;
            car.CategoryId = 33;
            car.LocationId = 99;

            directmessages.CreateReservation(car);
            Console.ReadLine();
                                                              
            directmessages.GetReservationByID("5ec9be88387b6f433c43f0ef");
            Console.ReadLine(); 
        }
    }
}

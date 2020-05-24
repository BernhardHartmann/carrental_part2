using CarsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterClient;
using CarRequest;

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

            
            var locationID = 1;
            var categoryID = 2;
            directmessages.getRandomCar(locationID, categoryID);


            Category category = new Category();
            category.CategoryId = 3;
            category.Price = (decimal)50.0;
            category.CategoryLabel = "label";
            category.CategoryDesc = "descr";

            /*directmessages.CreateReservation(car,category);
            Console.ReadLine();
                                                              
            directmessages.GetReservationByID("5ec9be88387b6f433c43f0ef");
            Console.ReadLine();    */
        }
    }
}

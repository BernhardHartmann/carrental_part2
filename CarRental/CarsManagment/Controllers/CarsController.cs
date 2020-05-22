using carsManagementService;
using carsManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarsManagment.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarManagementService _carManagementService ;
        private readonly carsManagementService.Models.Carsrepository<Car> carsrepository;

        public CarsController()
        {
            _carManagementService = new CarManagementService();
        }

        // GET api/car/id
        public HttpResponseMessage Get(int id)
        {

            var car = _carManagementService.Get(id);
            if (car != null)
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage GetAll()
        {
            var cars = _carManagementService.GetAll();
            if (cars.Any())
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public void Post([FromBody]Car car)
        {
            _carManagementService.Insert(car);

        }

        public void PostCar(Car car)
        {
            var carData = new Car(car);
            carsrepository.GetAll();
            _carManagementService.Insert(carData);
           // return RedirectToAction("Index");
        }

        public void Delete(int id)
        {
            _carManagementService.Delete(id);
        }
        public void Put([FromBody]Car car)
        {
            _carManagementService.Update(car);
        }
    }
}
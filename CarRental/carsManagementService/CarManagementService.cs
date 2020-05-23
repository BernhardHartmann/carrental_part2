using carsManagementService.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carsManagementService
{
    public class CarManagementService : ICarManagementService
    {
        private readonly CarConnector _carConnector;
        public CarManagementService()
        {
            _carConnector = new CarConnector();
        }
        public Car Get(int i)
        {
            return _carConnector.Cars.Get(i);
        }
        public IQueryable<Car> GetAll()
        {
            return _carConnector.Cars.GetAll();
        }
        public void Delete(int id)
        {
           // _carConnector.Cars.Delete( s=> s.Id, Query.EQ("_id", new ObjectId(id.ToString())).ToString());// (s => s.CarID, id);
        }
        public void Insert(Car car)
        {
            _carConnector.Cars.Add(car);
        }
        public void Update(Car car)
        {
            _carConnector.Cars.Update(s => s.CarID, car.CarID, car);
        }
    }
}

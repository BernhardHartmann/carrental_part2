using carsManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carsManagementService
{
    public interface ICarManagementService
    {
        void Insert(Car car);
        Car Get(int i);
        IQueryable<Car> GetAll();
        void Delete(int id);
        void Update(Car student);
    }
}

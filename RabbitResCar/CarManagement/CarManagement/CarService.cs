using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarManagement
{

    public class CarService
    {
        public readonly CarDBConnector Context = new CarDBConnector();

        public CarService()
        {
        }

        // Cars
        public int getLatestCarId()
        {
            //var c = Context.Customers.AsQueryable().Count();
            return Context.Cars.AsQueryable().OrderByDescending(r => r.CarId).FirstOrDefault().CarId;

        }

        public async Task<string> postCar(int carId, int categoryId, int locationId, string carDesc, string password, string color, 
            string brand, string model, string engineNumber, DateTime purchaseDate, int kilometer, string petrol, int isAvailable)
        {
            try
            {

                //var isCustomerRegistered = await _CustomerRepository.CustomerAlreadyRegistered(email);

                //if (isCustomerRegistered)
                {
                    //var errorMessage = $"There is already a customer registered with the e-mail {email}";

                    //return new CustomerResponseDto(new Exception(errorMessage), false);
                }

                byte[] passwordHash, passwordSalt;

                Utilities.GeneratePasswordHash(password, out passwordHash, out passwordSalt);

                var carToCreate = new Car()
                {
                    CarId = getLatestCarId() + 1,
                    CategoryId = categoryId,                   
                    LocationId = locationId,
                    CarDesc = carDesc,
                    Color = color,
                    Brand = brand,
                    Model = model,
                    EngineNumber = engineNumber,
                    PurchaseDate = purchaseDate,
                    Kilometer = kilometer,
                    Petrol = petrol,
                    IsAvailable = isAvailable
                };

                Context.Cars.Insert(carToCreate);
              
            }
            catch (Exception ex)
            {
                var errorMessage = $"{ex.Message} : {ex.InnerException}";
                return (JsonConvert.SerializeObject(false));
                //return new CustomerResponseDto(new Exception(errorMessage), false);
            }

            return (JsonConvert.SerializeObject(true));
        }

        public string markCarAsReserved(string dokumentID)
        {
            Car car = Context.Cars.AsQueryable().ToList().Where(x=> x.Id == dokumentID).FirstOrDefault();
            car.IsAvailable = -1; // reserved
            try
            {
                var filter = Builders<Car>.Filter.Eq("Id", dokumentID);
                var collection = Context.Database.GetCollection<BsonDocument>("Cars");
                var update = Builders<Car>.Update.Set("IsAvailable", -1);

                //Query.EQ("_id", new ObjectId(id)));
                // not finished

            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(false));
            }
            return (JsonConvert.SerializeObject(true));

        }

        public string getCarCountPerCategory()
        {
            Dictionary<int, int> data = new Dictionary<int, int>();
            try
            {
                var cars = Context.Cars.AsQueryable().ToList();
                var categories = Context.Categories.AsQueryable();              
                
                foreach (var cat in categories)
                {
                    
                    data.Add(cat.CategoryId, cars.Where(x=> x.CategoryId == cat.CategoryId && x.IsAvailable != 0).Count());
                }
            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(data));
            }
            return (JsonConvert.SerializeObject(data));
        }


        public string DeleteCarByDocumentID(string id)
        {
            try
            {
                Context.Cars.Remove(Query.EQ("_id", new ObjectId(id)));

            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(false));
            }
            return (JsonConvert.SerializeObject(true));
        }

        public async Task<string> DeleteCarByCarID(int customerId)
        {
            try
            {
                Context.Cars.Remove(Query.EQ("CarId", customerId));

            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(false));
            }
            return (JsonConvert.SerializeObject(true));
        }
        // Locations
        public string getLocationList()
        {
            //var c = Context.Customers.AsQueryable().Count();
            return JsonConvert.SerializeObject(Context.Locations.AsQueryable().ToList());

        }

        // documentid, Locid, Catid, Carid
        public string get_CarCount_CategoryCount_PerLocation( int LocId =0, int CatID = 0) // 0 means all
        {
            Tuple<string, int, int, int>[] dataArray = new Tuple<string, int, int, int>[50];
            try
            {
                
                var locations = Context.Locations.AsQueryable().ToList();                
                var categories = Context.Categories.AsQueryable().ToList();
                var cars = Context.Cars.AsQueryable().ToList();
                if (LocId > 0)
                    locations = locations.Where(x => x.LocationId == LocId).ToList();
                if (CatID > 0)
                    categories = categories.Where(x => x.CategoryId == CatID).ToList();

                //List<Category> tempCategoryList = new List<Category>();
                int i = 0;
                int count = 0;
                foreach (var loc in locations)
                {
                    var tempCategoryList = cars.Where(c => c.LocationId == loc.LocationId).Select(s => s.CategoryId).Distinct().ToList();
                    tempCategoryList.ForEach(
                        x=> {                            
                                {
                                    count = cars.Where(c => c.LocationId == loc.LocationId && c.CategoryId == x).Count();
                                    dataArray[i] = new Tuple<string, int, int, int>("", loc.LocationId, x, count);
                                    i++;
                                }
                        }
                    );

                }
            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(dataArray));
            }
            return (JsonConvert.SerializeObject(dataArray));
        }

        // getrandom Car
        public string get_RandomCarBy_Category_And_Location(int LocId , int CatID ) 
        {
            Car randomCar = new Car();
            try
            {

                var locations = Context.Locations.AsQueryable().ToList();
                var categories = Context.Categories.AsQueryable().ToList();
                var cars = Context.Cars.AsQueryable().ToList();
                if (LocId > 0)
                    locations = locations.Where(x => x.LocationId == LocId).ToList();
                if (CatID > 0)
                    categories = categories.Where(x => x.CategoryId == CatID).ToList();

                randomCar = cars.Where(c => c.LocationId == LocId  && c.CategoryId == CatID).Count() > 0 ? (Car)cars.Where(c => c.LocationId == LocId && c.CategoryId == CatID).FirstOrDefault() : randomCar;


            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(randomCar));
            }
            return (JsonConvert.SerializeObject(randomCar));
        }

        // Categories
        public string getCategoriesList()
        {
            //var c = Context.Customers.AsQueryable().Count();
            return JsonConvert.SerializeObject(Context.Categories.AsQueryable().ToList());

        }

        public string getCategoriesListPerLocation( int LocID)
        {           
            var cars = Context.Cars.AsQueryable().ToList();
            var categories = cars.Where(x => x.LocationId == LocID).Distinct().Select(s => s.CategoryId).ToList();
            return JsonConvert.SerializeObject(categories);

        }

    }
}

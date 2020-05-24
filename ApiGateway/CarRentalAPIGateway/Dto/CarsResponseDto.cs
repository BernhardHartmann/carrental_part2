using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CarsResponseDto
    {

        [JsonProperty(PropertyName = "carID")]
        public int CarId { get; set; }

        [JsonProperty(PropertyName = "categoryID")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "locationID")]
        public int LocationID { get; set; }

        [JsonProperty(PropertyName = "petrolID")]
        public int PetrolID { get; set; }

        [JsonProperty(PropertyName = "carDescription")]
        public string CarDescription { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "engineNumber")]
        public string EngineNumber { get; set; }

        [JsonProperty(PropertyName = "kilometer")]
        public int Kilometer { get; set; }

        [JsonProperty(PropertyName = "isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty(PropertyName = "purchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

        public CarsResponseDto(int car_id, int category_id, int location_id, int petrol_id, string cardesc, string color, string brand, string model, string engineNumber, DateTime purchaseDate, int kilometer, bool isAvailable, bool success)
        {
            CarId = car_id;
            CategoryID = category_id;
            LocationID = location_id;
            PetrolID = petrol_id;
            CarDescription = cardesc;
            Color = color;
            Brand = brand;
            Model = model;
            EngineNumber = engineNumber;
            PurchaseDate = purchaseDate;
            Kilometer = kilometer;
            IsAvailable = isAvailable;
            IsCommandSuccessful = success;
        }

        public CarsResponseDto(Exception exception, bool success)
        {
            Exception = exception;
            IsCommandSuccessful = success;
        }

        public CarsResponseDto(int carID, int categoryID, int locationID,int petrol_id, string engineNumber, bool success)
        {
            CarId = carID;
            CategoryID = categoryID;
            PetrolID = petrol_id;
            LocationID = locationID;
            EngineNumber= engineNumber;
            IsCommandSuccessful = success;

        }

        public CarsResponseDto()
        {

        }
    }
}

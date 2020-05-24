using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CarsDto
    {

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

    }
}

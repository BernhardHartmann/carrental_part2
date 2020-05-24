using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CategoriesToLocationsDto
    {
        [JsonProperty(PropertyName = "carID")]
        public int CarId { get; set; }

        [JsonProperty(PropertyName = "categoryID")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "categoryPrice")]
        public decimal CategoryPrice { get; set; }

        [JsonProperty(PropertyName = "discountMultiplier")]
        public decimal DiscountMultiplier { get; set; }

        [JsonProperty(PropertyName = "petrolId")]
        public int PetrolId { get; set; }

        [JsonProperty(PropertyName = "amountAvailable")]
        public int AmountAvailable { get; set; }

        [JsonProperty(PropertyName = "petrolType")]
        public string PetrolType { get; set; }

        [JsonProperty(PropertyName = "carDescription")]
        public string CarDescription { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "kilometer")]
        public int Kilometer { get; set; }

        [JsonProperty(PropertyName = "isAvailable")]
        public int IsAvailable { get; set; }


        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

    }
}

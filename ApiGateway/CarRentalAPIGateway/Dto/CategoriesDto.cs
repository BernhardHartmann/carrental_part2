using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CategoriesDto
    {

        [JsonProperty(PropertyName = "category_id")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "category_desc")]
        public string CategoryDesc { get; set; }

        [JsonProperty(PropertyName = "category_label")]
        public string CategoryLabel { get; set; }

        [JsonProperty(PropertyName = "category_image")]
        public string CategoryImage { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "amount_available_cars")]
        public int AmountAvailableCars { get; set; }

        [JsonProperty(PropertyName = "discount_multiplier")]
        public double DiscountMultiplier { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

    }
}

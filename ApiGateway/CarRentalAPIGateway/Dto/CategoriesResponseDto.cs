using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CategoriesResponseDto
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
        public decimal Price { get; set; } 
        
        [JsonProperty(PropertyName = "amount_available_cars")]
        public int AmountAvailableCars { get; set; }

        [JsonProperty(PropertyName = "discount_multiplier")]
        public double DiscountMultiplier { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

        public CategoriesResponseDto(int categoryID, string categoryDesc, string categoryLabel,string categoryImage, decimal price, bool success)
        {
            CategoryID = categoryID;
            CategoryDesc = categoryDesc;
            CategoryLabel = categoryLabel;
            CategoryImage = categoryImage;
            Price = price;
           // DiscountMultiplier = discountMultiplier;
           // AmountAvailableCars = amountAvailableCars;
          
            IsCommandSuccessful = success;
        }

        public CategoriesResponseDto(Exception exception, bool success)
        {
            Exception = exception;
            IsCommandSuccessful = success;
        } 
        
        public CategoriesResponseDto(int categoryID, bool success)
        {
            CategoryID = categoryID;
            IsCommandSuccessful = success;
        }   

        public CategoriesResponseDto()
        {

        }
    }
}

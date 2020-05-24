using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class DiscountResponseDto
    {

        [JsonProperty(PropertyName = "price")]
        public decimal? Price { get; set; }  
        
        [JsonProperty(PropertyName = "discountMultiplier")]
        public decimal? DiscountMultiplier { get; set; } 
        
        [JsonProperty(PropertyName = "isDiscount")]
        public bool IsDiscount { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

        public DiscountResponseDto(Exception exception, bool success)
        {
            Exception = exception;
            IsCommandSuccessful = success;
        }

        public DiscountResponseDto( bool success)
        {
            IsCommandSuccessful = success;
        }

        public DiscountResponseDto(decimal? newPrice, decimal? discountMultiplier, bool isDiscount, bool success)
        {
            Price = newPrice;
            IsDiscount = isDiscount;
            DiscountMultiplier = discountMultiplier;
            IsCommandSuccessful = success;
        }
      
        public DiscountResponseDto()
        {

        }
    }

    public class DiscountResponseWithCarDto
    {

        [JsonProperty(PropertyName = "price")]
        public decimal? Price { get; set; }

        [JsonProperty(PropertyName = "discountMultiplier")]
        public decimal? DiscountMultiplier { get; set; }

        [JsonProperty(PropertyName = "isDiscount")]
        public bool IsDiscount { get; set; } 
        
        [JsonProperty(PropertyName = "carID")]
        public int CarID { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

        public DiscountResponseWithCarDto(Exception exception, bool success)
        {
            Exception = exception;
            IsCommandSuccessful = success;
        }

        public DiscountResponseWithCarDto(bool success)
        {
            IsCommandSuccessful = success;
        }

        public DiscountResponseWithCarDto(decimal? newPrice, int carID, decimal? discountMultiplier, bool isDiscount, bool success)
        {
            Price = newPrice;
            IsDiscount = isDiscount;
            CarID = carID;
            DiscountMultiplier = discountMultiplier;
            IsCommandSuccessful = success;
        }

        public DiscountResponseWithCarDto()
        {

        }
    }
}

using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CategoriesToLocationsResponseDto
    {

        [JsonProperty(PropertyName = "categoryID")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "categoryPrice")]
        public decimal CategoryPrice { get; set; }
        
        [JsonProperty(PropertyName = "categoryDescription")]
        public string CategoryDesc { get; set; }  
        
        [JsonProperty(PropertyName = "categoryImage")]
        public string CategoryImage { get; set; }

        [JsonProperty(PropertyName = "amountAvailable")]
        public int AmountAvailable { get; set; }   
        
        [JsonProperty(PropertyName = "amountNotAvailable")]
        public int AmountNotAvailable { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

        public CategoriesToLocationsResponseDto(Exception exception, bool success)
        {
            Exception = exception;
            IsCommandSuccessful = success;
        }         
        
        public CategoriesToLocationsResponseDto(int categoryID, bool success)
        {
            CategoryID = categoryID;
            IsCommandSuccessful = success;
        }

        public CategoriesToLocationsResponseDto(int categoryID, int amountAvailable, int amountNotAvailable, string categoryImage, string categoryDesc, decimal categoryPrice, bool success)
        {
            CategoryID = categoryID;
            AmountAvailable = amountAvailable;
            AmountNotAvailable = amountNotAvailable;
            CategoryPrice = categoryPrice;
            CategoryDesc = categoryDesc;
            CategoryImage = categoryImage;
            IsCommandSuccessful = success;

        }

        public CategoriesToLocationsResponseDto(int categoryID, int amountAvailable, int amountNotAvailable, bool success)
        {
            CategoryID = categoryID;
            AmountAvailable = amountAvailable;
            AmountNotAvailable = amountNotAvailable;
            IsCommandSuccessful = success;

        }

        public CategoriesToLocationsResponseDto()
        {

        }
    }
}

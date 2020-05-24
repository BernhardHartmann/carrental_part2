using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class LocationResponseDto
    {
        [JsonProperty(PropertyName = "locationID")]
        public int LocationId { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "branchname")]
        public string BranchName { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "streetNO")]
        public string Streetno { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; } 
        
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "zipCode")]
        public string Zipcode { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }

        public LocationResponseDto(int location_id, string longitude, string latitude, string branchname, string street, string streetno, string country,string city, string zipcode, bool success)
        {
            LocationId = location_id;
            Longitude = longitude;
            Latitude = latitude;
            BranchName = branchname;
            Street = street;
            Streetno = streetno;
            Country = country;
            City = city;
            Zipcode = zipcode;
            IsCommandSuccessful = success;
        }

        public LocationResponseDto(Exception exception, bool success)
        {
            Exception = exception;
            IsCommandSuccessful = success;
        }   
        
        public LocationResponseDto(int locationID, string branchname, bool success)
        {
            LocationId = locationID;
            BranchName = branchname;
            IsCommandSuccessful = success;

        }

        public LocationResponseDto()
        {

        }
    }
}

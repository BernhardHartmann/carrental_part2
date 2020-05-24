using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class LocationModelDto
    {

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; } 
        
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

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

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

    }
}

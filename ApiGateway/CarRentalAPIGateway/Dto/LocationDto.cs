using Newtonsoft.Json;

namespace CarRentalAPIGateway.Dto
{
    public class LocationDto
    {

        [JsonProperty(PropertyName = "location_id")]
        public int LocationId { get; set; }

        [JsonProperty(PropertyName = "branchname")]
        public string BranchName { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "street_no")]
        public string Streetno { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "zip_code")]
        public string Zipcode { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }
    }
}

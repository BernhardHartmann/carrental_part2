using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class ReservationDto
    {
        [JsonProperty(PropertyName = "reservation_id")]
        public int ReservationID { get; set; }

        [JsonProperty(PropertyName = "reservation_status")]
        public string ReservationStatus { get; set; }

        [JsonProperty(PropertyName = "date_from")]
        public DateTime DateFrom { get; set; }

        [JsonProperty(PropertyName = "date_to")]
        public DateTime DateTo { get; set; }

        [JsonProperty(PropertyName = "reservation_price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "branchname")]
        public string BranchName { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "street_no")]
        public string StreetNo { get; set; }

        [JsonProperty(PropertyName = "zipcode")]
        public string Zipcode { get; set; }

    }
}

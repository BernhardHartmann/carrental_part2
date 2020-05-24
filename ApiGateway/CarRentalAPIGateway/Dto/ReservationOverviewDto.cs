using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class ReservationOverviewDto
    {
        [JsonProperty(PropertyName = "reservation_id")]
        public int ReservationID { get; set; }

        [JsonProperty(PropertyName = "date_from")]
        public DateTime DateFrom { get; set; }

        [JsonProperty(PropertyName = "date_to")]
        public DateTime DateTo { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
    }
}

using CarRentalAPIGateway.Enums;
using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class ReservationNormalDto
    {
       
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "currency_id")]
        public int CurrencyID { get; set; }

        [JsonProperty(PropertyName = "customer_id")]
        public int CustomerID { get; set; }

        [JsonProperty(PropertyName = "date_from")]
        public DateTime DateFrom { get; set; }

        [JsonProperty(PropertyName = "date_to")]
        public DateTime DateTo { get; set; }

        [JsonProperty(PropertyName = "reservationStatus")]
        public ReservationStatus ReservationStatus { get; set; }

        [JsonProperty(PropertyName = "carStatus")]
        public string CarStatus { get; set; }

        [JsonProperty(PropertyName = "reservationNote")]
        public string ReservationNote { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "kilometer_spent")]
        public decimal? KilometerSpent { get; set; }

        [JsonProperty(PropertyName = "returnTime")]
        public DateTime ReturnTime { get; set; }

    }
}

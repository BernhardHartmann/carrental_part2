using CarRentalAPIGateway.Enums;
using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class AllReservationDataResponse
    {

        [JsonProperty(PropertyName = "car_id")]
        public int CarId { get; set; }

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
        public decimal? Price { get; set; }

        [JsonProperty(PropertyName = "kilometer_spent")]
        public decimal? KilometerSpent { get; set; }

        [JsonProperty(PropertyName = "returnTime")]
        public DateTime ReturnTime { get; set; }

        [JsonProperty(PropertyName = "success")]

        public bool IsCommandSuccessful { get; set; }


        public AllReservationDataResponse(int carID, int currencyId, int customerId, DateTime dateFrom, DateTime dateTo, ReservationStatus resStatus, string carStatus, string resNote, decimal? price, int kilometerSpent, DateTime returnTime, bool success)
        {
            CarId = carID;
            CurrencyID = currencyId;
            CustomerID = customerId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            ReservationStatus = resStatus;
            CarStatus = carStatus;
            ReservationNote = resNote;
            Price = price;
            KilometerSpent = kilometerSpent;
            ReturnTime = returnTime;
            IsCommandSuccessful = success;
        }
    }
}

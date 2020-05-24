using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class ReservationResponseDto
    {
        [JsonProperty(PropertyName = "reservation_id")]
        public int? ReservationID { get; set; }

        [JsonProperty(PropertyName = "isSuccessful")]
        public bool IsSuccessful { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public string Exception { get; set; }

        public ReservationResponseDto(Exception exception)
        {
            Exception = exception.Message;
            IsSuccessful = false;
            ReservationID = null;
        }
        public ReservationResponseDto(Exception exception, bool success)
        {
            Exception = exception.Message;
            IsSuccessful = false;
            ReservationID = null;
        }

        public ReservationResponseDto(int id, bool success)
        {
            ReservationID = id;
            IsSuccessful = success;
            Exception = null;
        }
    }
}

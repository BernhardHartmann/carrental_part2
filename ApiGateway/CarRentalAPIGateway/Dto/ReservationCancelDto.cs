using Newtonsoft.Json;

namespace CarRentalAPIGateway.Dto
{
    public class ReservationCancelDto
    {
        [JsonProperty(PropertyName = "reservation_id")]
        public int ReservationID { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }
}

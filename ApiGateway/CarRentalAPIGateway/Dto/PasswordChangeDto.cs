using Newtonsoft.Json;

namespace CarRentalAPIGateway.Dto
{
    public class PasswordChangeDto
    {
        [JsonProperty(PropertyName = "customer_id")]
        public int CustomerID { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}

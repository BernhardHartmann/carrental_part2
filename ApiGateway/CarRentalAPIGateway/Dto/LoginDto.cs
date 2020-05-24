using Newtonsoft.Json;

namespace CarRentalAPIGateway.Dto
{
    /// <summary>
    /// Login model
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Mail
        /// </summary>
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}

using Newtonsoft.Json;

namespace CarRentalAPIGateway.Dto
{
    /// <summary>
    /// Model for the user registration
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// FirstName
        /// </summary>
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

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

        /// <summary>
        /// Role
        /// </summary>
        [JsonProperty(PropertyName = "currencyId")]
        public int CurrencyID { get; set; }
    }
}

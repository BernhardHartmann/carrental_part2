using Newtonsoft.Json;

namespace CarRentalAPIGateway.Dto
{
    public class CurrencyDto
    {
        [JsonProperty(PropertyName = "currency_id")]
        public int CurrencyID { get; set; }

        [JsonProperty(PropertyName = "currency_name")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }
    }
}

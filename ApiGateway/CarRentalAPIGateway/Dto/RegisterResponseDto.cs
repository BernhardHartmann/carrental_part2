using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class RegisterResponseDto
    {
        [JsonProperty(PropertyName = "registrationId")]
        public int? RegistrationID { get; set; }

        [JsonProperty(PropertyName = "registrationDate")]
        public DateTime? RegistrationDate { get; set; }

        [JsonProperty(PropertyName = "isRegistrationSuccessful")]
        public bool IsRegistrationSuccessful { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public string ExceptionMessage { get; set; }

        [JsonProperty(PropertyName = "eMail")]
        public string RegistrationEmail { get; set; }

        public RegisterResponseDto(Exception ex, bool isSuccess)
        {
            ExceptionMessage = ex.Message;
            IsRegistrationSuccessful = isSuccess;
            RegistrationEmail = null;
            RegistrationDate = null;
            RegistrationID = null;
        }

        public RegisterResponseDto(int id, bool isSuccess, string eMail)
        {
            RegistrationID = id;
            IsRegistrationSuccessful = isSuccess;
            ExceptionMessage = null;
            RegistrationDate = DateTime.Now;
            RegistrationEmail = eMail;
        }
    }
}

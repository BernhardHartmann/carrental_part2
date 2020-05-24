using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class CustomerResponseDto
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public string ExceptionMessage { get; set; }

        [JsonProperty(PropertyName = "isUpdateSuccessful")]
        public bool IsUpdateSuccessful { get; set; }

        public CustomerResponseDto(Exception exception)
        {
            ExceptionMessage = exception.Message;
            IsUpdateSuccessful = false;
            Id = null;
            UpdatedAt = null;
        }
         public CustomerResponseDto(int id, bool success)
        {
            Id = id;
            UpdatedAt = DateTime.Now;
            IsUpdateSuccessful = success;
            ExceptionMessage = null;
        }
    }
}

using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    /// <summary>
    /// LoginResponseDto
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Id of logged in user
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Date and time when the user logged in
        /// </summary>
        [JsonProperty(PropertyName = "loginDateTime")]
        public string LoginDateTime { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        [JsonProperty(PropertyName = "exception")]
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Whether the login was successful
        /// </summary>
        [JsonProperty(PropertyName = "isLoginSuccessful")]
        public bool IsLoginSuccessful { get; set; }

        /// <summary>
        /// JWT
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public LoginResponseDto()
        {

        }

        /// <summary>
        /// Constructs the response object with an exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="isLoginSuccessful"></param>
        public LoginResponseDto(Exception exception, bool isLoginSuccessful)
        {
            ExceptionMessage = exception.Message;
            IsLoginSuccessful = isLoginSuccessful;
            Id = null;
        }

        /// <summary>
        /// LoginResponseDto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginDateTime"></param>
        /// <param name="isLoginSuccessful"></param>
        public LoginResponseDto(int id, string loginDateTime, bool isLoginSuccessful, string token)
        {
            Id = id;
            LoginDateTime = loginDateTime;
            ExceptionMessage = null;
            IsLoginSuccessful = isLoginSuccessful;
            Token = token;
        }
    }
}

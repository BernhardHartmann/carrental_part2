using CarRentalAPIGateway.Dto;
using CarRentalAPIGateway.Enums;
using CarRentalAPIGateway.RabbitMQCommunication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarRentalAPIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private JsonSerializerSettings _jsonSerializerSettings;
        private ILogger<GatewayController> _logger;
        private IRabbitMQCommunication _rabbitMQCommunication;
        private IConfiguration _configuration;

        public GatewayController(ILogger<GatewayController> logger, IRabbitMQCommunication rabbitMQCommunication, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _rabbitMQCommunication = rabbitMQCommunication;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DateFormatString = "dd.MM.yyyy hh:MM:ss"
            };
        }

        [HttpGet]
        [Route("/services/rest/v1/utilities/currencies")]
        public IActionResult GetCurrencies()
        {
            try
            {
                var result = new List<CurrencyDto>()
                {
                    new CurrencyDto
                    {
                        CurrencyID = 1,
                        CurrencyName = "US Dollar",
                        CurrencyCode = "USD",
                        CurrencySymbol = "$"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 2,
                        CurrencyName = "Japanese Yen",
                        CurrencyCode = "JPY",
                        CurrencySymbol = "¥"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 3,
                        CurrencyName = "Bulgarian Lev",
                        CurrencyCode = "BGN",
                        CurrencySymbol = "Bl"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 4,
                        CurrencyName = "Czech koruna",
                        CurrencyCode = "CZN",
                        CurrencySymbol = "Kč"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 5,
                        CurrencyName = "Danish krone",
                        CurrencyCode = "DKK",
                        CurrencySymbol = "Dkr"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 6,
                        CurrencyName = "Pound sterling",
                        CurrencyCode = "GBP",
                        CurrencySymbol = "£"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 7,
                        CurrencyName = "Hungarian forint",
                        CurrencyCode = "HUF",
                        CurrencySymbol = "Ft"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 8,
                        CurrencyName = "Polish zloty",
                        CurrencyCode = "PLN",
                        CurrencySymbol = "zł"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 9,
                        CurrencyName = "Romanian leu",
                        CurrencyCode = "RON",
                        CurrencySymbol = "RL"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 10,
                        CurrencyName = "Swedish krona",
                        CurrencyCode = "SEK",
                        CurrencySymbol = "Skr"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 11,
                        CurrencyName = "Swiss franc",
                        CurrencyCode = "CHF",
                        CurrencySymbol = "Fr"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 12,
                        CurrencyName = "Icelandic krona",
                        CurrencyCode = "ISK",
                        CurrencySymbol = "Ikr"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 13,
                        CurrencyName = "Norwegian krone",
                        CurrencyCode = "NOK",
                        CurrencySymbol = "Nkr"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 14,
                        CurrencyName = "Croatian kuna",
                        CurrencyCode = "HRK",
                        CurrencySymbol = "kn"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 15,
                        CurrencyName = "Russian rouble",
                        CurrencyCode = "RUB",
                        CurrencySymbol = "Rr"     
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 16,
                        CurrencyName = "Turkish lira",
                        CurrencyCode = "TRY",
                        CurrencySymbol = "Tl"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 17,
                        CurrencyName = "Australian dollar",
                        CurrencyCode = "AUD",
                        CurrencySymbol = "A$"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 18,
                        CurrencyName = "Brazilian real",
                        CurrencyCode = "BRL",
                        CurrencySymbol = "R$"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 19,
                        CurrencyName = "Canadian dollar",
                        CurrencyCode = "CAD",
                        CurrencySymbol = "C$"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 20,
                        CurrencyName = "Chinese yuan renminbi",
                        CurrencyCode = "CNY",
                        CurrencySymbol = "¥" 
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 21,
                        CurrencyName = "Hong Kong dollar",
                        CurrencyCode = "HKD",
                        CurrencySymbol = "HK$"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 22,
                        CurrencyName = "Indonesian rupiah",
                        CurrencyCode = "IDR",
                        CurrencySymbol = "Rp"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 23,
                        CurrencyName = "Israeli shekel",
                        CurrencyCode = "ILS",
                        CurrencySymbol = "Is"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 24,
                        CurrencyName = "Indian rupee",
                        CurrencyCode = "INR",
                        CurrencySymbol = "Ip"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 25,
                        CurrencyName = "South Korean won",
                        CurrencyCode = "KRW",
                        CurrencySymbol = "SKw"   
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 26,
                        CurrencyName = "Mexican peso",
                        CurrencyCode = "MXN",
                        CurrencySymbol = "M$"  
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 27,
                        CurrencyName = "Malaysian ringgit",
                        CurrencyCode = "MYR",
                        CurrencySymbol = "RM"      
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 28,
                        CurrencyName = "New Zealand dollar",
                        CurrencyCode = "NZD",
                        CurrencySymbol = "NZ$" 
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 29,
                        CurrencyName = "Philippine peso",
                        CurrencyCode = "PHP",
                        CurrencySymbol = "Pp"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 30,
                        CurrencyName = "Singapore dollar",
                        CurrencyCode = "SGD",
                        CurrencySymbol = "S$"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 31,
                        CurrencyName = "Thai baht",
                        CurrencyCode = "THB",
                        CurrencySymbol = "Tb"
                    },
                    new CurrencyDto
                    {
                        CurrencyID = 32,
                        CurrencyName = "South African rand",
                        CurrencyCode = "ZAR",
                        CurrencySymbol = "R"
                    }
                };

                var jsonToReturn = JsonConvert.SerializeObject(result, _jsonSerializerSettings);

                return new OkObjectResult(jsonToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} : {ex.InnerException}");
                var content = StatusCode((int)HttpStatusCode.InternalServerError);
                return Content(JsonConvert.SerializeObject(content), MediaType.ApplicationJson);
            }
        }

        [HttpGet]
        [Route("/services/rest/v1/utilities/locations")]
        public IActionResult GetLocations()
        {
            try
            {
                var result = new List<LocationDto>()
                {
                    new LocationDto
                    {
                        LocationId = 1,
                        BranchName = "Train Station",
                        City = "Vienna",
                        State = "Vienna",
                        Street = "Europaplatz",
                        Streetno = "2",
                        Zipcode = "1150",
                        Country = "Austria",
                        Latitude = "48.196850",
                        Longitude = "16.337870"
                    },
                    new LocationDto
                    {
                        LocationId = 2,
                        BranchName = "Inner City",
                        City = "Vienna",
                        State = "Vienna",
                        Street = "Seilergasse",
                        Streetno = "5",
                        Zipcode = "1001",
                        Country = "Austria",
                        Latitude = "48.207380",
                        Longitude = "16.371040"
                    }
                };

                var jsonToReturn = JsonConvert.SerializeObject(result, _jsonSerializerSettings);

                return new OkObjectResult(jsonToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} : {ex.InnerException}");
                var content = StatusCode((int)HttpStatusCode.InternalServerError);
                return Content(JsonConvert.SerializeObject(content), MediaType.ApplicationJson);
            }
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme, Roles = "Customer")]
        [Route("/services/rest/v1/customer/register")]
        public IActionResult RegisterCustomer([FromBody]RegisterDto registerDto)
        {
            try
            {
                if (registerDto == null)
                    return BadRequest(registerDto);

                var isSentMessage = _rabbitMQCommunication.SendMessage(JsonConvert.SerializeObject(registerDto), "customers.queue", "request.customers", "request.register.customer");
                var reply = _rabbitMQCommunication.ReceiveMessage("customers.queue");

                string jsonToReturn;

                if (!string.IsNullOrEmpty(reply))
                {
                    jsonToReturn = JsonConvert.SerializeObject(reply, _jsonSerializerSettings);
                    return new OkObjectResult(jsonToReturn);
                }
                else
                {
                    jsonToReturn = string.Empty;
                    return BadRequest(jsonToReturn);
                }
            }
            catch (Exception ex)
            {
                var content = StatusCode((int)HttpStatusCode.BadRequest, $"{ex.Message} : {ex.InnerException}");
                return Content(JsonConvert.SerializeObject(content), MediaType.ApplicationJson);
            }
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme, Roles = "Customer")]
        [Route("/services/rest/v1/customer/login")]
        public IActionResult Login([FromBody]LoginDto loginDto)
        {
            try
            {
                if (loginDto == null) return BadRequest(loginDto);

                var isSentMessage = _rabbitMQCommunication.SendMessage(JsonConvert.SerializeObject(loginDto, _jsonSerializerSettings), "user.login", "test", "test");
                var reply = _rabbitMQCommunication.ReceiveMessage("user.register");

                string jsonToReturn;

                if (!string.IsNullOrEmpty(reply))
                {
                    jsonToReturn = JsonConvert.SerializeObject(reply, _jsonSerializerSettings);
                    return new OkObjectResult(jsonToReturn);
                }
                else
                {
                    jsonToReturn = string.Empty;
                    return BadRequest(jsonToReturn);
                }
            }
            catch (Exception ex)
            {
                var content = StatusCode((int)HttpStatusCode.BadRequest, $"{ex.Message} : {ex.InnerException}");
                return Content(JsonConvert.SerializeObject(content), MediaType.ApplicationJson);
            }
        }


        [HttpGet]
        //[Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme, Roles = "Customer")]
        [Route("/services/rest/v1/reservation/customer/get/{id}")]
        public IActionResult GetReservationById(string id)
        {
            try
            {
                var isSentMessage = _rabbitMQCommunication.SendMessage(JsonConvert.SerializeObject(id, _jsonSerializerSettings), "reservation.queue", "request.reservation", "reservation.get.by.id");
                var reply = _rabbitMQCommunication.ReceiveMessage("reservation.queue");

                string jsonToReturn;

                if (!string.IsNullOrEmpty(reply))
                {
                    jsonToReturn = JsonConvert.SerializeObject(reply, _jsonSerializerSettings);
                    return new OkObjectResult(jsonToReturn);
                }
                else
                {
                    jsonToReturn = string.Empty;
                    return BadRequest(jsonToReturn);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} : {ex.InnerException}");
                var content = StatusCode((int)HttpStatusCode.InternalServerError);
                return Content(JsonConvert.SerializeObject(content), MediaType.ApplicationJson);
            }
        }

        [HttpPost]
        [Route("/services/rest/v1/reservation/createReservation")]
        // [Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme, Roles = "Customer")]
        public async Task<IActionResult> CreateReservation([FromBody]ReservationNormalDto reservationDto)
        {
            try
            {
                if (reservationDto == null)
                    return BadRequest(reservationDto);

                var serializedObject = JsonConvert.SerializeObject(reservationDto);
                var isSentMessage = _rabbitMQCommunication.SendMessage(serializedObject, "reservation.queue", "request.reservation", "reservation.create");
                var reply = _rabbitMQCommunication.ReceiveMessage("reservation.queue");

                string jsonToReturn;

                if (!string.IsNullOrEmpty(reply))
                {
                    jsonToReturn = JsonConvert.SerializeObject(reply, _jsonSerializerSettings);
                    return new OkObjectResult(jsonToReturn);
                }
                else
                {
                    jsonToReturn = string.Empty;
                    return BadRequest(jsonToReturn);
                }
            }
            catch (Exception ex)
            {
                var content = StatusCode((int)HttpStatusCode.BadRequest, $"{ex.Message} : {ex.InnerException}");
                return Content(JsonConvert.SerializeObject(content), "application/json");
            }
        }
    }
}

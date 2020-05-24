using CarRentalAPIGateway.Enums;
using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class AllReservationDataDto
    {
        //Cars
        [JsonProperty(PropertyName = "car_id")]
        public int CarId { get; set; }

        [JsonProperty(PropertyName = "carName")]
        public string CarName { get; set; }

        [JsonProperty(PropertyName = "carImage")]
        public string CarImage { get; set; }

        [JsonProperty(PropertyName = "carBrand")]
        public string CarBrand { get; set; }

        //Category
        [JsonProperty(PropertyName = "category_id")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonProperty(PropertyName = "categoryDesc")]

        //Period or Category
        public string CategoryDescription { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        //Period

        [JsonProperty(PropertyName = "discountMultiplier")]
        public decimal DiscountMultiplier { get; set; }

       
        //customerData

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }


        //Reservation 
        [JsonProperty(PropertyName = "kilometer_spent")]
        public decimal? KilometerSpent { get; set; }

        //Reservation 
        [JsonProperty(PropertyName = "reservation_status")]
        public ReservationStatus ReservationStatus { get; set; }

        [JsonProperty(PropertyName = "returnTime")]
        public DateTime? ReturnTime { get; set; }

        [JsonProperty(PropertyName = "reservationDateFrom")]
        public DateTime? ReservationDateFrom { get; set; }

        [JsonProperty(PropertyName = "reservationDateTo")]
        public DateTime? ReservationDateTo { get; set; }

        //General
        [JsonProperty(PropertyName = "exception")]
        public string ExceptionMessage { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsCommandSuccessful { get; set; }


        public AllReservationDataDto(string ex, bool success)
        {
            ExceptionMessage = ex;
            IsCommandSuccessful = success;
        }

        public AllReservationDataDto(int carId, string carImage, string carbrand, int categoryID, string categoryLabel, string categoryDesc, decimal price, string email, string lastname, decimal? kilometerSpent, DateTime reservationDateFrom, DateTime reservationDateTo, bool success)
        {
            CarId = carId;
            CarImage = carImage;
            CarBrand = carbrand;
            CategoryID = categoryID;
            CategoryLabel = categoryLabel;
            CategoryDescription = categoryDesc;
            Price = price;
            Email = email;
            Lastname = lastname;
            KilometerSpent = kilometerSpent;
            ReservationDateFrom = reservationDateFrom;
            ReservationDateTo = reservationDateTo;
            IsCommandSuccessful = success;

        }
    }
}

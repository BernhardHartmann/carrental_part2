using CarRentalAPIGateway.Enums;
using Newtonsoft.Json;
using System;

namespace CarRentalAPIGateway.Dto
{
    public class ReservationNormalDto
    {
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public int CategoryID { get; set; }
        public int LocationID { get; set; }
        public int CurrencyID { get; set; }
        public double Price { get; set; }
        public string CurrencyExchangeRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

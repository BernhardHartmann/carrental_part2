﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationConsumer
{
    class Reservation
    {
        public ObjectId _id { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }
        public int LocationID { get; set; }
        public string CurrencyID { get; set; }
        public double Price { get; set; }
        public string CurrencyExchangeRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

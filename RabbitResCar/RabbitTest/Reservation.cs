using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationRequest
{
    class Reservation
    {
        public int UserID { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }
        public int LocationID { get; set; }
        public int CurrencyID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

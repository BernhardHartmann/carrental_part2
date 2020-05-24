using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRequest
{
    class ClassTotal_carCat
    {
		public int CarId { get; set; }
		public int CategoryId { get; set; }
		public int LocationId { get; set; }
	
		public int IsAvailable { get; set; }

		public decimal? Price { get; set; }
	}
}

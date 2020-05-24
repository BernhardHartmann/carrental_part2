using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmanagementConsumer
{
	public class Car
	{
		public string Id { get; set; }
		public int CarId { get; set; }
		public int CategoryId { get; set; }
		public int LocationId { get; set; }
		public string CarDesc { get; set; }
		public string Color { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string EngineNumber { get; set; }
		public DateTime? PurchaseDate { get; set; }
		public int? Kilometer { get; set; }
		public int PetrolId { get; set; }
		public int IsAvailable { get; set; }
	}
}
